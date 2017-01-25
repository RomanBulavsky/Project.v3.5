using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Repositories;

namespace RFoundation.DAL.Implementation.Repositories
{
    public class ExtensionRepository : IExtensionRepository
    {
        private DbContext Context { get; set; }

        public ExtensionRepository(DbContext context)
        {
            Context = context;
        }

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
