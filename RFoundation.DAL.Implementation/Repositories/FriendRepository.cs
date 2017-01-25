using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RFoundation.DAL.Implementation.Mappers;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Repositories;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private DbContext Context { get; set; }

        public FriendRepository(DbContext context)
        {
            Context = context;
        }


        public IEnumerable<DalFriend> GetAll()
        {
            var friends = Context.Set<Friend>()?.ToList();
            var dalFriends = friends?.Select(f => f.ToDalFriend());
            return dalFriends;
        }

        public DalFriend Get(int id)
        {
            var friend = Context.Set<Friend>()?.Find(id);
            return friend?.ToDalFriend();
        }

        public DalFriend GetByPredicate(Expression<Func<DalFriend, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFriend entity)
        {
            var ormFriend = entity?.ToOrmFriend();
            if (ormFriend == null) return;
            Context.Set<Friend>()?.Add(ormFriend);
        }

        public void Delete(DalFriend entity)
        {
            var ormFriend = entity?.ToOrmFriend();
            if (ormFriend == null) return;
            Context.Set<Friend>()?.Remove(ormFriend);
        }

        public void Delete(int id)
        {
            var ormFriend = Context.Set<Friend>()?.Find(id);
            if (ormFriend == null) return;
            Context.Set<Friend>().Remove(ormFriend);
        }

        public void Update(DalFriend entity)
        {
            if (entity == null) return;
            var ormFriend =
                Context.Set<Friend>()?
                    .FirstOrDefault(fr => fr.Id == entity.Id);
            if (ormFriend == null) return;
            ormFriend.Id = entity.Id;
            ormFriend.FriendId = entity.FriendId;
            ormFriend.UserId = entity.UserId;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
