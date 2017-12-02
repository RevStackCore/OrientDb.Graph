using RevStackCore.Pattern;


namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbVertexRepository<TVertex, TKey> : IRepository<TVertex, TKey>
        where TVertex : class, IOrientEntity<TKey>
    {

    }
}
