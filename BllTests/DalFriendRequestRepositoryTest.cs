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
    public class DalFriendRequestRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(1, 2)]
        public void GetById(int fromId, int toId)
        {
            var friendRequest =
                UnitOfWork.FriendRequestRepository.Get(new DalFriendRequest() {ToUserId = toId, FromUserId = fromId});
            Assert.AreEqual(friendRequest.Confirmed, null);
        }

        [Order(1)]
        [TestCase(1, 8)]
        public void CreateFriendRequest(int fromId, int toId)
        {
            var friendRequest = new DalFriendRequest() {FromUserId = fromId, ToUserId = toId};
            UnitOfWork.FriendRequestRepository.Create(friendRequest);
            UnitOfWork.Commit();

            var friendRequestFromDb = UnitOfWork.FriendRequestRepository.Get(friendRequest);

            Assert.AreEqual(friendRequestFromDb.ToUserId, toId);
            Assert.AreEqual(friendRequestFromDb.FromUserId, fromId);
        }

        [Order(2)]
        [TestCase(1, 8, true)]
        public void UpdateFriendRequest(int fromId, int toId, bool confirmed)
        {
            var friendRequestFromDb =
                UnitOfWork.FriendRequestRepository.Get(new DalFriendRequest() {FromUserId = fromId, ToUserId = toId});
            friendRequestFromDb.Confirmed = confirmed;
            UnitOfWork.FriendRequestRepository.Update(friendRequestFromDb);
            UnitOfWork.Commit();

            var newFriendRequestFromDb = UnitOfWork.FriendRequestRepository.Get(friendRequestFromDb);
            Assert.AreEqual(newFriendRequestFromDb.Confirmed, confirmed);
        }

        [Order(3)]
        [TestCase(1, 8)]
        public void DeleteUser(int fromId, int toId)
        {
            var friendRequest = UnitOfWork.FriendRequestRepository.Get(new DalFriendRequest()
            {
                FromUserId = fromId,ToUserId = toId
            });
            UnitOfWork.FriendRequestRepository.Delete(friendRequest);
            UnitOfWork.Commit();

            var friendRequestFromDb = UnitOfWork.FriendRequestRepository.Get(friendRequest);
            
            Assert.IsNull(friendRequestFromDb);
        }

    }
}