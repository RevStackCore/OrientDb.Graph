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
        const string CONNECTION_STRING = "server=http://localhost:2480;database=xxxxx;user=xxxxx;password=xxxxxx";

        OrientDbContext dbContext;
        IRepository<User, string> userRepository;
        IRepository<Memorial, string> memorialRepository;
        IRepository<Friend, string> friendRepository;
        IRepository<MemorialUser, string> memorialUserRepository;
        IOrientDbGraphQueryRepository<Friend, string> friendQueryRepository;
        IOrientDbGraphQueryRepository<UserGraph, string> userGraphQueryRepository;

        public UnitTest1()
        {
            dbContext = new OrientDbContext(CONNECTION_STRING);
            userRepository = new OrientDbVertexRepository<User, string>(dbContext);
            memorialRepository = new OrientDbVertexRepository<Memorial, string>(dbContext);
            friendRepository = new OrientDbEdgeRepository<Friend, string>(dbContext);
            memorialUserRepository = new OrientDbEdgeRepository<MemorialUser, string>(dbContext);
            friendQueryRepository = new OrientDbGraphQueryRepository<Friend, string>(dbContext);
            userGraphQueryRepository = new OrientDbGraphQueryRepository<UserGraph, string>(dbContext);
        }

        [TestMethod]
        public void Create_Update_Entities()
        {
            //create users
            var user1 = new User { Age = 33, FirstName = "Jane", LastName = "Doe" };
            var user2 = new User { Age = 5, FirstName = "John", LastName = "Doe" };
            user1 = userRepository.Add(user1);
            user2 = userRepository.Add(user2);

            //create memorial
            var memorial = new Memorial { Name = "Bob's Memorial" };
            memorial = memorialRepository.Add(memorial);
            memorial.Name = "mem update";
            memorial = memorialRepository.Update(memorial);

            //edge friend
            var friend = new Friend
            {
                In = user1,
                Out = user2,
                Description = "Test meta on friends."
            };
            friend = friendRepository.Add(friend);
            friend = friendRepository.GetById(friend.Id);
            //edge memorial
            var memorialUser = new MemorialUser
            {
                Out = memorial,
                In = user1,
                Meta = "test meta on memorial & user."
            };
            memorialUser = memorialUserRepository.Add(memorialUser);

            //Update
            memorialUser.Meta = "meta update...";
            memorialUser = memorialUserRepository.Update(memorialUser);

            //Delete
            memorialUserRepository.Delete(memorialUser);
        }

        [TestMethod]
        public void Queryable()
        {
            //Generic query if you know resultset you can build out model
            var friendQueryable = friendQueryRepository.Find("select * from Friend");
            var friends = friendQueryable.ToList();

            //Orient only allows loading records once in the result set. Limitation...looking into a workaround.
            //Should return User with Memorials and friends
            //"SELECT id, firstName, lastName, age, out_MemorialUser as MemorialUser, out_Friend as Friend FROM ( SELECT EXPAND( IN('Friend') ) FROM User WHERE firstName ='John' )
            //var userGraphQueryable = userGraphQuery.Find("SELECT id, firstName, lastName, age, out_MemorialUser as MemorialUser, out_Friend as Friend FROM ( SELECT EXPAND( IN('Friend') ) FROM User WHERE firstName ='John' )");
            //var users = userGraphQueryable.ToList();
        }
        
    }
}
