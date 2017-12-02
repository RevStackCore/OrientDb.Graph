using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbVertexService<TVertex, TKey> where TVertex : class, IOrientEntity<TKey>
    {
        IEnumerable<TVertex> Get();
        TVertex GetById(TKey id);
        IQueryable<TVertex> Find(Expression<Func<TVertex, bool>> predicate);
        TVertex Add(TVertex entity);
        TVertex Update(TVertex entity);
        void Delete(TVertex entity);
        Task<IEnumerable<TVertex>> GetAsync();
        Task<TVertex> GetByIdAsync(TKey id);
        Task<IQueryable<TVertex>> FindAsync(Expression<Func<TVertex, bool>> predicate);
        Task<TVertex> AddAsync(TVertex entity);
        Task<TVertex> UpdateAsync(TVertex entity);
        Task DeleteAsync(TVertex entity);
    }
}
