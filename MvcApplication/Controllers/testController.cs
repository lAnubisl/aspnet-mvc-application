using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class TestPermission
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }
    public class TestUser
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TestPermission> Permissions { get; set; }
    }
    public class TestModel
    {
        public IEnumerable<TestPermission> Permissions { get; set; } 
        public IEnumerable<TestUser> Users { get; set; }
    }
    public class testController : Controller
    {
        //
        // GET: /test/

        public ActionResult Index()
        {
            var permission1 = new TestPermission() {Id = 1, Title = "Permission 1"};
            var permission2 = new TestPermission() {Id = 2, Title = "Permission 2"};
            var permission3 = new TestPermission() {Id = 3, Title = "Permission 3"};

            var user1 = new TestUser
                            {
                                Id = 1,
                                Name = "User 1",
                                Permissions = new List<TestPermission> {permission1, permission2}
                            };
            var user2 = new TestUser
                            {
                                Id = 2,
                                Name = "User 2",
                                Permissions = new List<TestPermission> {permission2, permission3}
                            };
            var user3 = new TestUser
                            {
                                Id = 3,
                                Name = "User 3",
                                Permissions = new List<TestPermission> {permission1, permission3}
                            };

            return
                View(new TestModel
                         {
                             Users = new List<TestUser>() {user1, user2, user3},
                             Permissions = new List<TestPermission>() {permission1, permission2, permission3}
                         });
        }

    }
}
