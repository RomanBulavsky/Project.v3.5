using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Implementations
{
    public class ExtensionRepository : IExtensionRepository
    {
        public IEnumerable<DalExtension> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalExtension Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalExtension GetByPredicate(Expression<Func<DalExtension, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalExtension entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalExtension entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalExtension entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
