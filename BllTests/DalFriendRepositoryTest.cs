using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.DAL.Implementation;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace DalTests
{
    [TestFixture]
    public class DalFriendRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(1, 4)]
        public void GetById(int id, int friendId)
        {
            var friend = UnitOfWork.FriendRepository.Get(id);
            Assert.AreEqual(friend.FriendId, friendId);
        }

        [Order(1)]
        [TestCase(1, 2)]
        public void CreateFriendship(int userId, int friendId)
        {
            var friendship = new DalFriend() {FriendId = friendId, UserId = userId};
            UnitOfWork.FriendRepository.Create(friendship);
            UnitOfWork.Commit();

            var friendshipFromDb =
                UnitOfWork.FriendRepository.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == friendId);

            Assert.AreEqual(friendshipFromDb.FriendId, friendId);
        }

        [Order(2)]
        [TestCase(1, 2, 3)]
        public void UpdateExtension(int userId, int oldfriendId, int newFriendId)
        {
            var friendship =
                UnitOfWork.FriendRepository.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == oldfriendId);
            var id = friendship.Id;
            friendship.FriendId = newFriendId;
            UnitOfWork.FriendRepository.Update(friendship);
            UnitOfWork.Commit();

            var newFriendship = UnitOfWork.FriendRepository.Get(id);
            Assert.AreEqual(newFriendship.FriendId, newFriendId);
        }

        [Order(3)]
        [TestCase(1, 3)]
        public void DeleteUser(int userId, int friendId)
        {
            var friendship =
                UnitOfWork.FriendRepository.GetAll()
                    .FirstOrDefault(fs => fs.UserId == userId && fs.FriendId == friendId);
            UnitOfWork.FriendRepository.Delete(friendship.Id);
            UnitOfWork.Commit();

            var friendshipFromDb = UnitOfWork.ExtensionRepository.Get(friendship.Id);
            Assert.IsNull(friendshipFromDb);
        }
    }
}