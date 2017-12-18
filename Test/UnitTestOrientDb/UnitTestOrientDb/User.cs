using RevStackCore.OrientDb.Graph;

namespace UnitTestOrientDb
{
    public class User : IOrientEntity<string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ApplicationUser : IOrientEntity<string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
