using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class Memorial : IEntity<string>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        #region "orientdb meta"
        public string _rid { get; set; }
        public string _class { get; set; }
        public int _version { get; set; }
        #endregion
    }
}
