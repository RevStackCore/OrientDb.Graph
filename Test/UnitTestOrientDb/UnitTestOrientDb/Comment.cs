using System;
using RevStackCore.OrientDb.Graph;

namespace UnitTestOrientDb
{
    public class Comment : IOrientEntity<string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Permalink { get; set; }

        public Comment()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
