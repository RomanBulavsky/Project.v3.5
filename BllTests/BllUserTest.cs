using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.BLL.Implementation.Services;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Implementation;
using RFoundation.ORM.Database;

namespace BllTests
{
    [TestFixture]
    public class BllUserTest
    {
        private IUserService userService;

        private IUserService UserService
            => userService ?? (userService = new UserService(new UnitOfWork(new FileStorageDatabaseContext())));


        [Test]
        [TestCase(2, "2")]
        public void TakeIds(int userId, string login)
        {
            var user = UserService.Get(userId);
            Assert.AreEqual(user.Login,login);
        }
    
    }
}
