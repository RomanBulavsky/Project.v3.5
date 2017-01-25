using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using RFoundation.DAL.Implementation.Mappers;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Repositories;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Repositories
{
    public class SharedFileRepository : ISharedFileRepository
    {
        private DbContext Context { get; set; }

        public SharedFileRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalSharedFile> GetAll()
        {
            var sharedFiles = Context.Set<SharedFile>()?.ToList();
            var dalSharedFiles = sharedFiles?.Select(f => f.ToDalSharedFile());
            return dalSharedFiles;
        }

        public DalSharedFile Get(int id)
        {
            var sharedFile = Context.Set<SharedFile>()?.Find(id);
            return sharedFile?.ToDalSharedFile();
        }

        public DalSharedFile GetByPredicate(Expression<Func<DalSharedFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalSharedFile entity)
        {
            var ormSharedFile = entity?.ToOrmSharedFile();
            if (ormSharedFile == null) return;
            Context.Set<SharedFile>()?.Add(ormSharedFile);
        }

        public void Delete(DalSharedFile entity)
        {
            var ormSharedFile = entity?.ToOrmSharedFile();
            if (ormSharedFile == null) return;
            Context.Set<SharedFile>()?.Remove(ormSharedFile);
        }

        public void Delete(int id)
        {
            var sharedFile = Context.Set<File>()?.Find(id);
            if (sharedFile == null) return;
            Context.Set<File>().Remove(sharedFile);
        }

        public void Update(DalSharedFile entity)
        {
            if (entity == null) return;
            var ormSharedFile = Context.Set<SharedFile>()?.FirstOrDefault(sf => sf.FileId == entity.FileId);
            if(ormSharedFile == null) return;
            ormSharedFile.OwnerId = entity.OwnerId;
            ormSharedFile.RecipientId = entity.RecipientId;
            ormSharedFile.FileId = entity.FileId;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}