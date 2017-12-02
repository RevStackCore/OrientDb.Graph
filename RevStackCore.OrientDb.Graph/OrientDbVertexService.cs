using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public class OrientDbVertexService<TVertex, TKey> : IOrientDbVertexService<TVertex, TKey> where TVertex : class, IOrientEntity<TKey>
    {
        protected readonly IOrientDbVertexRepository<TVertex, TKey> _repository;

        public OrientDbVertexService(IOrientDbVertexRepository<TVertex, TKey> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<TVertex> Get()
        {
            return _repository.Get();
        }

        public virtual TVertex GetById(TKey id)
        {
            return _repository.GetById(id);
        }

        public virtual Task<IEnumerable<TVertex>> GetAsync()
        {
            return Task.FromResult(Get());
        }

        public virtual Task<TVertex> GetByIdAsync(TKey id)
        {
            return Task.FromResult(GetById(id));
        }

        public virtual IQueryable<TVertex> Find(Expression<Func<TVertex, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public virtual Task<IQueryable<TVertex>> FindAsync(Expression<Func<TVertex, bool>> predicate)
        {
            return Task.FromResult(Find(predicate));
        }

        public virtual TVertex Add(TVertex entity)
        {
            return _repository.Add(entity);
        }

        public virtual Task<TVertex> AddAsync(TVertex entity)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TVertex Update(TVertex entity)
        {
            return _repository.Update(entity);
        }

        public virtual Task<TVertex> UpdateAsync(TVertex entity)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual void Delete(TVertex entity)
        {
            _repository.Delete(entity);
        }

        public virtual Task DeleteAsync(TVertex entity)
        {
            return Task.Run(() => Delete(entity));
        }
    }
}
