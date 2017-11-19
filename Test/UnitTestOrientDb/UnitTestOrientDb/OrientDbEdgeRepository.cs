using RevStackCore.OrientDb;
using RevStackCore.Pattern;
using System.Linq;

namespace UnitTestOrientDb
{
    public class OrientDbEdgeRepository<TEntity, TKey> : OrientDbRepository<TEntity, TKey>, IOrientDbEdgeRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbContext _context;

        public OrientDbEdgeRepository(OrientDbContext context)
            : base(context)
        {
            _context = context;
        }

        public void Add(TEntity entity, string from, string to)
        {
            var name = entity.GetType().Name;
            _context.Database.Execute("CREATE CLASS " + name + " EXTENDS E");
            //_context.Database.Execute("CREATE PROPERTY " + name + ".id STRING");
            //_context.Database.Execute("CREATE INDEX " + name + ".id UNIQUE");
            //base.Add(entity);
            _context.Database.Execute("CREATE EDGE " + name + " FROM " + from + " to " + to);
            //return base.GetById(entity.Id);
        }
    }
}
