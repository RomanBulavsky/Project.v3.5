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
    public class RoleService : IRoleService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public RoleService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllRole> GetAll()
        {
            var roles = UnitOfWork?.RoleRepository?.GetAll();
            return roles?.Select(r => r.ToBllRole());
        }

        public BllRole Get(int id)
        {
            var role = UnitOfWork?.RoleRepository?.Get(id);
            return role?.ToBllRole();
        }

        public BllRole GetByPredicate(Expression<Func<BllRole, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllRole entity)
        {
            if (entity == null) return;
            UnitOfWork?.RoleRepository?.Create(entity.ToDalRole());
        }

        public void Delete(BllRole entity)
        {
            if (entity == null) return;
            UnitOfWork?.RoleRepository?.Delete(entity.ToDalRole());
        }

        public void Delete(int id)
        {
            UnitOfWork?.RoleRepository?.Delete(id);
        }

        public void Update(BllRole entity)
        {
            if (entity == null) return;
            UnitOfWork?.RoleRepository?.Update(entity.ToDalRole());
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}