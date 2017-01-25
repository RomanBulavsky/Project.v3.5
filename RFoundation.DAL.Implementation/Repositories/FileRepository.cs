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
    public class FileRepository : IFileRepository
    {
        private DbContext Context { get; set; }

        public FileRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalFile> GetAll()
        {
            var files = Context.Set<File>().ToList();
            var dalFiles = files.Select(u => u.ToDalFile());
            return dalFiles;
        }

        public DalFile Get(int id)
        {
            var file = Context.Set<File>().Find(id);
            return file.ToDalFile();
        }

        public DalFile GetByPredicate(Expression<Func<DalFile, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalFile entity)
        {
            var ormFile = entity.ToOrmFile();
            Context.Set<File>().Add(ormFile);
        }

        public void Delete(DalFile entity)
        {
            var file = entity.ToOrmFile();
            Context.Set<File>().Remove(file);
        }

        public void Delete(int id)
        {
            var file = Context.Set<File>().Find(id);
            Context.Set<File>().Remove(file);

        }

        public void Update(DalFile entity)
        {
            var ormFile = Context.Set<File>().Find(entity.Id);
            ormFile.Name = entity.Name;
            ormFile.Data = entity.Data;
            ormFile.Banned = entity.Banned;
            ormFile.Size = entity.Size;
            ormFile.IsProfileImage = entity.IsProfileImage;
            ormFile.ExtensionId = entity.ExtensionId;
            ormFile.IsFolder = entity.IsFolder;
            ormFile.ParentFileFolderId = entity.ParentFileFolderId;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}