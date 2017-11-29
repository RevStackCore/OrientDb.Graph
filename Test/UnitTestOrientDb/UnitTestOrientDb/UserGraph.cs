using System.Collections.Generic;
using RevStackCore.Pattern;

namespace UnitTestOrientDb
{
    public class UserGraph : IEntity<string>
    {
        public string Id { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Friend> Friend { get; set; }
        public List<MemorialUser> MemorialUser { get; set; }
    }
}
