using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Repositories;

namespace RFoundation.DAL.Implementation.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private DbContext Context { get; set; }

        public FriendRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalFriendRequest> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalFriendRequest Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalFriendRequest GetByPredicate(Expression<Func<DalFriendRequest, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalFriendRequest entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
