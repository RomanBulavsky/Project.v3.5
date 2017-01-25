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
    public class ExtensionRepository : IExtensionRepository
    {
        private DbContext Context { get; set; }

        public ExtensionRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalExtension> GetAll()
        {
            var extensions = Context.Set<Extension>().ToList();
            var dalExtensions = extensions?.Select(e => e.ToDalExtension());
            return dalExtensions;
        }

        public DalExtension Get(int id)
        {
            var extension = Context.Set<Extension>()?.Find(id);
            return extension?.ToDalExtension();
        }

        public DalExtension GetByPredicate(Expression<Func<DalExtension, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalExtension entity)
        {
            var ormExtension = entity?.ToOrmExtension();
            if (ormExtension == null) return;
            Context.Set<Extension>()?.Add(ormExtension);
        }

        public void Delete(DalExtension entity)
        {
            var ormExtension = entity?.ToOrmExtension();
            if (ormExtension == null) return;
            Context.Set<Extension>()?.Remove(ormExtension);
        }

        public void Delete(int id)
        {
            var extension = Context.Set<Extension>()?.Find(id);
            if (extension == null) return;
            Context.Set<Extension>().Remove(extension);
        }

        public void Update(DalExtension entity)
        {
            if (entity == null) return;
            var ormExtension = Context.Set<Extension>()?.Find(entity.Id);
            if (ormExtension == null) return;
            ormExtension.Id = entity.Id;
            ormExtension.ExtensionName = entity.ExtensionName;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
