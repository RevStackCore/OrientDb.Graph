using RevStackCore.Pattern;


namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientDbEdgeRepository<TEdge, TIn, TOut, TKey> : IRepository<TEdge, TKey>
        where TEdge : class, IOrientEdgeEntity<TIn, TOut, TKey>
        where TIn : class, IOrientEntity<TKey>
        where TOut : class, IOrientEntity<TKey>
    {

    }
}
