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
    public class FileSharingService : IFileSharingService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public FileSharingService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllSharedFile> GetAll()
        {
            var sharedFiles = UnitOfWork?.SharedFileRepository?.GetAll();
            return sharedFiles?.Select(sf => sf.ToBllSharedFileFile());
        }

        public BllSharedFile Get(BllSharedFile entity)
        {
            //TODO: Exc??
            if (entity == null) return null;
            var sharedFile = UnitOfWork?.SharedFileRepository?.Get(entity.ToDalSharedFile());
            return sharedFile?.ToBllSharedFileFile();
        }

        public BllSharedFile Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllSharedFile GetByPredicate(Expression<Func<BllSharedFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllSharedFile entity)
        {
            if(entity == null) return;
            UnitOfWork?.SharedFileRepository?.Create(entity.ToDalSharedFile());
            UnitOfWork?.Commit();
        }

        public void Delete(BllSharedFile entity)
        {
            if (entity == null) return;
            UnitOfWork?.SharedFileRepository?.Delete(entity.ToDalSharedFile());
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllSharedFile entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
