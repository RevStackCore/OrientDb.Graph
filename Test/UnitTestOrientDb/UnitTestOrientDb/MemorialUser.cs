using RevStackCore.OrientDb.Graph;

namespace UnitTestOrientDb
{
    public class MemorialUser : IOrientEdgeEntity<User, Memorial, string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string Meta { get; set; }

        #region "orientdb graph vertex"
        public User In { get; set; }
        public Memorial Out { get; set; }
        #endregion
    }
}
