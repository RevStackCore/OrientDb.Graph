using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class MemorialUser : IEntity<string>
    {
        public string Id { get; set; }
        public string Meta { get; set; }

        #region "orientdb graph"
        public User In { get; set; }
        public Memorial Out { get; set; }
        #endregion

        #region "orientdb meta"
        public string _rid { get; set; }
        public string _class { get; set; }
        public int _version { get; set; }
        #endregion
    }
}
