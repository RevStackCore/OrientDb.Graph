using System;
using System.Collections.Generic;
using RevStackCore.OrientDb.Graph;

namespace UnitTestOrientDb
{
    public class Post : IOrientEntity<string>
    {
        public string Id { get; set; }
        public string RId { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Permalink { get; set; }
        public string Image { get; set; }
        public int SupportCount { get; set; }
        public int CommentsCount { get; set; }
        public int ShareCount { get; set; }

        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }
    }

    public class PostComments : Post
    {
        public IEnumerable<Comment> Comments { get; set; }
    }
}
