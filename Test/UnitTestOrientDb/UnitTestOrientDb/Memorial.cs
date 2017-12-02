using RevStackCore.OrientDb.Graph;


namespace UnitTestOrientDb
{
    public class Memorial : IOrientEntity<string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string Name { get; set; }
    }
}
