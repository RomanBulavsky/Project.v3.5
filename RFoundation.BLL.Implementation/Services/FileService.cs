using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RFoundation.BLL.Implementation.Mappers;
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
            var files = UnitOfWork?.FileRepository?.GetAll();
            return files?.Select(f => f.ToBllFile());
        }

        public BllFile Get(int id)
        {
            var file = UnitOfWork?.FileRepository?.Get(id);
            return file?.ToBllFile();
        }

        public BllFile GetByPredicate(Expression<Func<BllFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllFile entity)
        {
            if (entity == null) return;
            UnitOfWork?.FileRepository?.Create(entity.ToDalFile());
            UnitOfWork?.Commit();
        }

        public void Delete(BllFile entity)
        {
            if (entity == null) return;
            Delete(entity.Id);
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            UnitOfWork?.FileRepository?.Delete(id);
            UnitOfWork?.Commit();
        }

        public void Update(BllFile entity)
        {
            if (entity == null) return;
            UnitOfWork?.FileRepository?.Update(entity.ToDalFile());
            UnitOfWork?.Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}