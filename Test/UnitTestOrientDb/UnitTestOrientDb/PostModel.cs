using RevStackCore.Pattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestOrientDb
{
    public class AuthorModel
    {
        public string Id { get; set; }
        public string Avatar { get; set; }
        public string DisplayName { get; set; }
        public string Permalink { get; set; }
        public string Role { get; set; }
        public IEnumerable<string> GrieveList { get; set; }
    }
    public class ContentModel
    {
        public string Id { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
        public string Permalink { get; set; }
    }
    public class PostContentModel : ContentModel
    {
        public string Image { get; set; }
        public int SupportCount { get; set; }
        public int CommentsCount { get; set; }
        public int ShareCount { get; set; }
    }
    public class PostModel : PostContentModel, IEntity<string>
    {
        public string UserId { get; set; }
        public AuthorModel Author { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
        public PostModel()
        {
            Id = Guid.NewGuid().ToString();
            Author = new AuthorModel();
            Comments = new List<CommentModel>();
        }
    }
    public class CommentModel : ContentModel
    {
        public string UserId { get; set; }
        public AuthorModel Author { get; set; }
        public CommentModel()
        {
            Id = Guid.NewGuid().ToString();
            Author = new AuthorModel();
        }
    }
}
