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
    public class FriendService : IFriendService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FriendService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllFriend> GetAll()
        {
            var friends = UnitOfWork?.FriendRepository?.GetAll();
            return friends?.Select(f => f.ToBllFriend());
        }

        public BllFriend Get(int id)
        {
            var friend = UnitOfWork?.FriendRepository?.Get(id);
            return friend?.ToBllFriend();
        }

        public BllFriend GetByPredicate(Expression<Func<BllFriend, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFriend entity)
        {
            if (entity == null) return;
            UnitOfWork?.FriendRepository?.Create(entity.ToDalFriend());
            UnitOfWork?.Commit();
        }

        public void Delete(BllFriend entity)
        {
            if (entity == null) return;
            Delete(entity.Id);
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            UnitOfWork?.FriendRepository?.Delete(id);
            UnitOfWork?.Commit();
        }

        public void Update(BllFriend entity)
        {
            if (entity == null) return;
            UnitOfWork?.FriendRepository?.Update(entity.ToDalFriend());
            UnitOfWork?.Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}