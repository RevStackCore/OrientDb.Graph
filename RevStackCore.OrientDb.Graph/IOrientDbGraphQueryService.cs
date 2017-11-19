using System.Linq;
using System.Threading.Tasks;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbGraphQueryService<TEntity, TKey>
    {
        Task<IQueryable<TEntity>> FindAsync(string query);
        IQueryable<TEntity> Find(string query);
    }
}
