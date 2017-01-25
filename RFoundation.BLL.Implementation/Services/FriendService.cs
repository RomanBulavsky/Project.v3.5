using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Interfaces;

namespace RFoundation.BLL.Implementation.Services
{
    public class FriendService : IFriendService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FriendService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllFriend> GetAll()
        {
            throw new NotImplementedException();
        }

        public BllFriend Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllFriend GetByPredicate(Expression<Func<BllFriend, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFriend entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BllFriend entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllFriend entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
