using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace UnitTestOrientDb
{
    public interface IOrientDbEdgeRepository<TEntity, TKey>
    {
        //void Add(TEntity entity, string from, string to);
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> Get();
        TEntity GetById(TKey id);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
