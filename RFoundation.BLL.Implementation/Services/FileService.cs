using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Interfaces;

namespace RFoundation.BLL.Implementation.Services
{
    public class FileService : IFileService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FileService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllFile> GetAll()
        {
            throw new NotImplementedException();
        }

        public BllFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllFile GetByPredicate(Expression<Func<BllFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BllFile entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllFile entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}