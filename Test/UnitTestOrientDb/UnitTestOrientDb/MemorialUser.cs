using RevStackCore.OrientDb;
using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class MemorialUser : OrientDbEntity, IEntity<string>
    {
        public string Id { get; set; }
        public string Meta { get; set; }
        public User In { get; set; }
        public Memorial Out { get; set; }
    }
}
