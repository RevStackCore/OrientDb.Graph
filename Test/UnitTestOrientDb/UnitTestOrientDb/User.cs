using RevStackCore.OrientDb;
using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class User : OrientDbEntity, IEntity<string>
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
