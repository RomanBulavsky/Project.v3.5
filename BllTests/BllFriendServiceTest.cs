using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.BLL.Implementation.Services;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Implementation;
using RFoundation.ORM.Database;

namespace BllTests
{
    [TestFixture]
    public class BllFriendServiceTest
    {
        private IFriendService userService;

        private IFriendService FriendService
            => userService ?? (userService = new FriendService(new UnitOfWork(new FileStorageDatabaseContext())));


        [TestCase(1, 4)]
        public void GetById(int id, int friendId)
        {
            var friend = FriendService.Get(id);
            Assert.AreEqual(friend.FriendId, friendId);
        }

        [Order(1)]
        [TestCase(1, 2)]
        public void CreateFriendship(int userId, int friendId)
        {
            var friendship = new BllFriend() { FriendId = friendId, UserId = userId };
            FriendService.Create(friendship);

            var friendshipFromDb =
                FriendService.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == friendId);

            Assert.AreEqual(friendshipFromDb.FriendId, friendId);
        }

        [Order(2)]
        [TestCase(1, 2, 3)]
        public void UpdateExtension(int userId, int oldfriendId, int newFriendId)
        {
            var friendship =
                FriendService.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == oldfriendId);
            var id = friendship.Id;
            friendship.FriendId = newFriendId;
            FriendService.Update(friendship);

            var newFriendship = FriendService.Get(id);
            Assert.AreEqual(newFriendship.FriendId, newFriendId);
        }

        [Order(3)]
        [TestCase(1, 3)]
        public void DeleteUser(int userId, int friendId)
        {
            var friendship =
                FriendService.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == friendId);
            FriendService.Delete(friendship.Id);

            var friendshipFromDb = FriendService.Get(friendship.Id);
            Assert.IsNull(friendshipFromDb);
        }
    }
}
