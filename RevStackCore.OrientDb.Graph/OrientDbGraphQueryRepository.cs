using System.Linq;
using RevStackCore.Pattern;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbGraphQueryRepository<TEntity, TKey> : IOrientDbGraphQueryRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbDatabase _database;
        private readonly HttpOrientDbGraphQueryProvider _queryProvider;

        public OrientDbGraphQueryRepository(OrientDbContext context)
        {
            _database = context.Database;
            _queryProvider = new HttpOrientDbGraphQueryProvider(context.Connection);
        }

        public IQueryable<TEntity> Find(string query)
        {
            _queryProvider.QueryText = query;
            return new GraphQuery<TEntity>(_queryProvider);
        }
    }
}
