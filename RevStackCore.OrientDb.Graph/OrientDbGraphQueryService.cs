using RevStackCore.Pattern;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbGraphQueryService<TEntity, TKey> : IOrientDbGraphQueryService<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        private readonly IOrientDbGraphQueryRepository<TEntity, TKey> _repository;

        public OrientDbGraphQueryService(IOrientDbGraphQueryRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public IQueryable<TEntity> Find(string query)
        {
            return _repository.Find(query);
        }

        public Task<IQueryable<TEntity>> FindAsync(string query)
        {
            return Task.FromResult(Find(query));
        }
    }
}
