using System.Reflection;
using RevStackCore.Pattern;


namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbEdgeRepository<TEntity, TKey> : OrientDbRepository<TEntity, TKey>, IOrientDbEdgeRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbContext _context;

        public OrientDbEdgeRepository(OrientDbContext context)
            : base(context)
        {
            _context = context;
        }

        public new TEntity Add(TEntity entity)
        {
            var type = entity.GetType();
            var name = type.Name;

            if (type.GetProperty("In") == null)
            {
                throw new System.Exception("'In' property of type OrientDbEntity is required");
            }

            if (type.GetProperty("Out") == null)
            {
                throw new System.Exception("'Out' property of type OrientDbEntity is required");
            }

            var In = (OrientDbEntity)type.GetProperty("In").GetValue(entity);
            var Out = (OrientDbEntity)type.GetProperty("Out").GetValue(entity);
            var typeName = Utils.OrientDbUtils.GetEntityIdType(entity);
            entity = Utils.OrientDbUtils.SetEntityIdProperty(entity);

            _context.Database.Execute("CREATE CLASS " + name + " EXTENDS E");

            //https://github.com/orientechnologies/orientdb/issues/5688
            //FIX: alter database custom standardElementConstraints=false
            _context.Database.Execute("CREATE PROPERTY " + name + ".id " + typeName);
            _context.Database.Execute("CREATE INDEX " + name + ".id UNIQUE");
            var q = "CREATE EDGE " + name + " FROM " + In._rid + " to " + Out._rid + " SET id = '" + entity.Id + "'";
            _context.Database.Execute(q);
            //var edge = base.GetById(entity.Id);
            return base.Update(entity);
        }

        public new TEntity Update(TEntity entity)
        {
            var type = entity.GetType();
            var name = entity.GetType().Name;

            if (type.GetProperty("In") == null)
            {
                throw new System.Exception("'To' property of type OrientDbEntity is required");
            }

            if (type.GetProperty("Out") == null)
            {
                throw new System.Exception("'From' property of type OrientDbEntity is required");
            }

            var In = (OrientDbEntity)type.GetProperty("In").GetValue(entity);
            var Out = (OrientDbEntity)type.GetProperty("Out").GetValue(entity);

            var q = "UPDATE EDGE " + name + " SET in = " + In._rid + ", out = " + Out._rid + " WHERE id ='" + entity.Id + "'";
            _context.Database.Execute(q);

            return base.Update(entity);
        }
    }
}
