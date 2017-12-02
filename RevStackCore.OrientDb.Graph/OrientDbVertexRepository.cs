

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbVertexRepository<TVertex, TKey> : OrientDbRepository<TVertex, TKey>, IOrientDbVertexRepository<TVertex, TKey> where TVertex : class, IOrientEntity<TKey>
    {
        private readonly OrientDbContext _context;

        public OrientDbVertexRepository(OrientDbContext context)
            :base(context)
        {
            _context = context;
        }
        
        public override TVertex Add(TVertex entity)
        {
            var name = entity.GetType().Name;
            _context.Database.Execute("CREATE CLASS " + name + " EXTENDS V");
            _context.Database.Execute("CREATE PROPERTY " + name + ".id STRING");
            _context.Database.Execute("CREATE INDEX " + name + ".id UNIQUE");

            return base.Add(entity);
        }

        public override void Delete(TVertex entity)
        {
            var name = entity.GetType().Name;
            _context.Database.Execute("DELETE VERTEX " + name + " where id = '" + entity.Id.ToString() + "'");
        }
    }
}
