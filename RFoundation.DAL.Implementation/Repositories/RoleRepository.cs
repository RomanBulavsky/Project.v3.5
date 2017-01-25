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
    public class RoleRepository : IRoleRepository
    {
        private DbContext Context { get; set; }

        public RoleRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles = Context.Set<Role>()?.ToList();
            var dalSharedFiles = roles?.Select(r => r.ToDalRole());
            return dalSharedFiles;
        }

        public DalRole Get(int id)
        {
            var role = Context.Set<Role>()?.Find(id);
            return role?.ToDalRole();
        }

        public DalRole GetByPredicate(Expression<Func<DalRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalRole entity)
        {
            var ormRole = entity?.ToOrmRole();
            if (ormRole == null) return;
            Context.Set<Role>()?.Add(ormRole);
        }

        public void Delete(DalRole entity)
        {
            var ormRole = entity?.ToOrmRole();
            if (ormRole == null) return;
            Context.Set<Role>()?.Remove(ormRole);
        }

        public void Delete(int id)
        {
            var ormRole = Context.Set<Role>()?.Find(id);
            if (ormRole == null) return;
            Context.Set<Role>().Remove(ormRole);
        }

        public void Update(DalRole entity)
        {
            if (entity == null) return;
            var ormRole = Context.Set<Role>()?.FirstOrDefault(r => r.Id == entity.Id);
            if (ormRole == null) return;
            ormRole.Id = entity.Id;
            ormRole.Name = entity.Name;
            ormRole.Users = entity.Users.Select(r => r.ToOrmUser()).ToList();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
