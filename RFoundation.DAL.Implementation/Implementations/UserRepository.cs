using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Implementations
{
    public class UserRepository : IUserRepository
    {
        public IEnumerable<DalUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
