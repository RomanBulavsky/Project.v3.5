using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Implementations
{
    public class SharedFileRepository : ISharedFileRepository
    {
        public IEnumerable<DalSharedFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalSharedFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalSharedFile GetByPredicate(Expression<Func<DalSharedFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalSharedFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalSharedFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalSharedFile entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
