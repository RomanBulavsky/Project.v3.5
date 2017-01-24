using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using RFoundation.DAL.Interfaces.DTO;
using RFoundation.DAL.Interfaces.SpecificInterface;

namespace RFoundation.DAL.Implementation.Repositories
{
    public class FileRepository : IFileRepository
    {
        private DbContext Context { get; set; }

        public FileRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public DalFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public DalFile GetByPredicate(Expression<Func<DalFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(DalFile entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}