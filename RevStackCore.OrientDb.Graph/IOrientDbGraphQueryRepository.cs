using System.Linq;

namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbGraphQueryRepository<TEntity, TKey>
    {
        IQueryable<TEntity> Find(string query);
    }
}
