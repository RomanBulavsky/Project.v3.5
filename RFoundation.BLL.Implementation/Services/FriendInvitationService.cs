using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RFoundation.BLL.Implementation.Mappers;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Interfaces;

namespace RFoundation.BLL.Implementation.Services
{
    public class FriendInvitationService : IFriendInvitationService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FriendInvitationService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllFriendRequest> GetAll()
        {
            var friendRequests = UnitOfWork?.FriendRequestRepository?.GetAll();
            return friendRequests?.Select(fr => fr.ToBllFriendRequest());
        }

        public BllFriendRequest Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllFriendRequest Get(BllFriendRequest entity)
        {
            if (entity == null) return null;
            return UnitOfWork?.FriendRequestRepository?.Get(entity.ToDalFriendRequest()).ToBllFriendRequest();
        }

        public BllFriendRequest GetByPredicate(Expression<Func<BllFriendRequest, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFriendRequest entity)
        {
            if (entity == null) return;
            UnitOfWork?.FriendRequestRepository?.Create(entity.ToDalFriendRequest());
            UnitOfWork?.Commit();
        }

        public void Delete(BllFriendRequest entity)
        {
            if (entity == null) return;
            UnitOfWork?.FriendRequestRepository?.Delete(entity.ToDalFriendRequest());
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllFriendRequest entity)
        {
            if (entity == null) return;
            UnitOfWork?.FriendRequestRepository?.Update(entity.ToDalFriendRequest());
            UnitOfWork?.Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }

    }
}
