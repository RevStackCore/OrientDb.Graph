using RevStackCore.Pattern;


namespace RevStackCore.OrientDb.Graph
{
    public interface IOrientEntity<TKey> : IEntity<TKey>
    {
        TKey RId { get; set; }
    }
}
