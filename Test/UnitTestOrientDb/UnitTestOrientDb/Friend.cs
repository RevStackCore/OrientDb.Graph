using RevStackCore.OrientDb;
using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class Friend : OrientDbEntity, IEntity<string>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public User In { get; set; }
        public User Out { get; set; }
    }
}
