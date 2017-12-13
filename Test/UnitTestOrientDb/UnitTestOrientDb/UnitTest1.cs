using Microsoft.VisualStudio.TestTools.UnitTesting;
using RevStackCore.OrientDb;
using RevStackCore.OrientDb.Graph;
using RevStackCore.Pattern;
using System.Linq;

namespace UnitTestOrientDb
{
    [TestClass]
    public class UnitTest1
    {
        const string CONNECTION_STRING = "server=http://localhost:2480;database=testgraph;user=admin;password=admin";

        OrientDbContext dbContext;
        IOrientDbVertexService<User, string> userService;
        IOrientDbVertexService<Memorial, string> memorialService;
        IOrientDbEdgeService<Friend, User, User, string> friendService;
        IOrientDbEdgeService<MemorialUser, User, Memorial, string> memorialUserService;

        //Query Service
        IOrientDbQueryService queryService;
       
        public UnitTest1()
        {
            dbContext = new OrientDbContext(CONNECTION_STRING);

            //vertex
            userService = new OrientDbVertexService<User, string>(new OrientDbVertexRepository<User, string>(dbContext));
            memorialService = new OrientDbVertexService<Memorial, string>(new OrientDbVertexRepository<Memorial, string>(dbContext));

            //edge
            friendService = new OrientDbEdgeService<Friend, User, User, string>(new OrientDbEdgeRepository<Friend, User, User, string>(dbContext));
            memorialUserService = new OrientDbEdgeService<MemorialUser, User, Memorial, string>(new OrientDbEdgeRepository<MemorialUser, User, Memorial, string>(dbContext));

            //query
            queryService = new OrientDbQueryService(new OrientDbQueryRepository(dbContext));
        }

        [TestMethod]
        public void Create_Update_Entities()
        {
            //create users
            var user1 = new User { Age = 33, FirstName = "Jane", LastName = "Doe" };
            var user2 = new User { Age = 5, FirstName = "John", LastName = "Doe" };
            user1 = userService.Add(user1);
            user2 = userService.Add(user2);

            //create memorial
            var memorial = new Memorial { Name = "Bob's Memorial" };
            memorial = memorialService.Add(memorial);
            memorial.Name = "mem update";
            memorial = memorialService.Update(memorial);

            //edge friend
            var friend = new Friend
            {
                In = user1,
                Out = user2,
                Description = "Test meta on friends."
            };
            friend = friendService.Add(friend);
            friend = friendService.GetById(friend.Id);
            //edge memorial
            var memorialUser = new MemorialUser
            {
                Out = memorial,
                In = user1,
                Meta = "test meta on memorial & user."
            };
            memorialUser = memorialUserService.Add(memorialUser);

            //Update
            memorialUser.Meta = "meta update...";
            memorialUser = memorialUserService.Update(memorialUser);

            //Delete
            memorialUserService.Delete(memorialUser);
        }

        [TestMethod]
        public void Queryable()
        {
            //Generic query if you know resultset you can build out model
            //var friendQueryable = queryService.Find<Friend>("select * from Friend");
            //var friends = friendQueryable.ToList();

            var firstName = "Jane";
            var users = userService.Find(x => x.FirstName.ToLower() == firstName.ToLower());
            var user = users.Any();
            Assert.AreNotEqual(false, user);

            //var query = friendService.Find(x => x.In.FirstName == firstName);
            //var friends = query.Count();
            //Assert.AreNotEqual(0, friends);

            //Orient only allows loading records once in the result set. Limitation...looking into a workaround.
            //Should return User with Memorials and friends
            //"SELECT id, firstName, lastName, age, out_MemorialUser as MemorialUser, out_Friend as Friend FROM ( SELECT EXPAND( IN('Friend') ) FROM User WHERE firstName ='John' )
            //var userGraphQueryable = userGraphQuery.Find("SELECT id, firstName, lastName, age, out_MemorialUser as MemorialUser, out_Friend as Friend FROM ( SELECT EXPAND( IN('Friend') ) FROM User WHERE firstName ='John' )");
            //var users = userGraphQueryable.ToList();
        }
        
    }
}
