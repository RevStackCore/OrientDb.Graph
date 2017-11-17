using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbVertexRepository<TEntity, TKey>
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity GetById(TKey id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
