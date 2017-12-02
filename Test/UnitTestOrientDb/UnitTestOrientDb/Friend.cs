using RevStackCore.OrientDb.Graph;

namespace UnitTestOrientDb
{
    public class Friend : IOrientEdgeEntity<User, User, string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string Description { get; set; }

        #region "orientdb graph vertex"
        public User In { get; set; }
        public User Out { get; set; }
        #endregion
    }
}
