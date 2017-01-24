using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<DalRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalRole Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
