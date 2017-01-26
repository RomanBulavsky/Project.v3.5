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
    public class FriendRequestRepository : IFriendRequestRepository
    {
        private DbContext Context { get; set; }

        public FriendRequestRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalFriendRequest> GetAll()
        {
            var friendRequests = Context.Set<FriendRequest>()?.ToList();
            var dalFriendRequests = friendRequests?.Select(fr => fr.ToDalFriendRequest());
            return dalFriendRequests;
        }
        
        public DalFriendRequest Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalFriendRequest Get(DalFriendRequest entity)
        {
            var friendRequest =
                GetAll().FirstOrDefault(fr => fr.ToUserId == entity.ToUserId && fr.FromUserId == entity.FromUserId);
            return friendRequest;
        }

        public DalFriendRequest GetByPredicate(Expression<Func<DalFriendRequest, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFriendRequest entity)
        {
            var ormFriendRequest = entity?.ToOrmFriendRequest();
            if (ormFriendRequest == null) return;
            Context.Set<FriendRequest>()?.Add(ormFriendRequest);
        }

        public void Delete(DalFriendRequest entity)
        {
            if(entity == null) return;
            var ormFriendRequest = Context.Set<FriendRequest>()?
                .FirstOrDefault(fr => fr.FromUserId == entity.FromUserId && fr.ToUserId == entity.ToUserId);
            if (ormFriendRequest == null) return;
            Context.Set<FriendRequest>()?.Remove(ormFriendRequest);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalFriendRequest entity)
        {
            if (entity == null) return;
            var ormFriendRequest =
                Context.Set<FriendRequest>()?
                    .FirstOrDefault(fr => (fr.FromUserId == entity.FromUserId) && (fr.ToUserId == entity.ToUserId));
            if (ormFriendRequest == null) return;
            ormFriendRequest.FromUserId = entity.FromUserId;
            ormFriendRequest.ToUserId = entity.ToUserId;
            ormFriendRequest.Confirmed = entity.Confirmed;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}