using System.Linq;
using RevStackCore.Pattern;
using RevStackCore.OrientDb.Graph.Client;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbGraphQuery<TEntity, TKey> : IOrientDbGraphQuery<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly OrientDbDatabase _database;
        private readonly HttpOrientDbGraphQueryProvider _queryProvider;

        public OrientDbGraphQuery(OrientDbContext context)
        {
            _database = context.Database;
            _queryProvider = new HttpOrientDbGraphQueryProvider(context.Connection);
        }

        public IQueryable<TEntity> Find(string query)
        {
            _queryProvider.QueryText = query;
            return new Query.GraphQuery<TEntity>(_queryProvider);
        }
    }
}
