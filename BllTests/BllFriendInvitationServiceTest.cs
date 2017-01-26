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
    public class BllFriendInvitationServiceTest
    {
        private IFriendInvitationService userService;

        private IFriendInvitationService FriendInvitationService
            => userService ?? (userService = new FriendInvitationService(new UnitOfWork(new FileStorageDatabaseContext())));


        [TestCase(1, 2)]
        public void GetById(int fromId, int toId)
        {
            var friendRequest =
                FriendInvitationService.Get(new BllFriendRequest() { ToUserId = toId, FromUserId = fromId });
            Assert.AreEqual(friendRequest.Confirmed, null);
        }

        [Order(1)]
        [TestCase(1, 8)]
        public void CreateFriendRequest(int fromId, int toId)
        {
            var friendRequest = new BllFriendRequest() { FromUserId = fromId, ToUserId = toId };
            FriendInvitationService.Create(friendRequest);

            var friendRequestFromDb = FriendInvitationService.Get(friendRequest);

            Assert.AreEqual(friendRequestFromDb.ToUserId, toId);
            Assert.AreEqual(friendRequestFromDb.FromUserId, fromId);
        }

        [Order(2)]
        [TestCase(1, 8, true)]
        public void UpdateFriendRequest(int fromId, int toId, bool confirmed)
        {
            var friendRequestFromDb =
                FriendInvitationService.Get(new BllFriendRequest() { FromUserId = fromId, ToUserId = toId });
            friendRequestFromDb.Confirmed = confirmed;
            FriendInvitationService.Update(friendRequestFromDb);

            var newFriendRequestFromDb = FriendInvitationService.Get(friendRequestFromDb);
            Assert.AreEqual(newFriendRequestFromDb.Confirmed, confirmed);
        }

        [Order(3)]
        [TestCase(1, 8)]
        public void DeleteFriendRequest(int fromId, int toId)
        {
            var friendRequest = FriendInvitationService.Get(new BllFriendRequest()
            {
                FromUserId = fromId,
                ToUserId = toId
            });
            FriendInvitationService.Delete(friendRequest);

            var friendRequestFromDb = FriendInvitationService.Get(friendRequest);

            Assert.IsNull(friendRequestFromDb);
        }
    }
}
