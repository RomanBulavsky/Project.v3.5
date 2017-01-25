using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            throw new NotImplementedException();
        }

        public BllFriendRequest Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllFriendRequest GetByPredicate(Expression<Func<BllFriendRequest, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BllFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
