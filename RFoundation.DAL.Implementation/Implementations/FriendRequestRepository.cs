using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Implementations
{
    public class FriendRequestRepository : IFriendRequestRepository
    {
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
