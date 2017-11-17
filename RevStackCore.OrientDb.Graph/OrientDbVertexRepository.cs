using RevStackCore.Pattern;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbVertexRepository<TEntity, TKey> : OrientDbRepository<TEntity, TKey>, IOrientDbVertexRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbContext _context;

        public OrientDbVertexRepository(OrientDbContext context)
            :base(context)
        {
            _context = context;
        }
        
        public new TEntity Add(TEntity entity)
        {
            var name = entity.GetType().Name;
            _context.Database.Execute("CREATE CLASS " + name + " EXTENDS V");
            _context.Database.Execute("CREATE PROPERTY " + name + ".id STRING");
            _context.Database.Execute("CREATE INDEX " + name + ".id UNIQUE");
            return base.Add(entity);
        }
    }
}
