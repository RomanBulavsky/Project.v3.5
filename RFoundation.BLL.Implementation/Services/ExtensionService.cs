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
    public class ExtensionService : IExtensionService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public ExtensionService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<BllExtension> GetAll()
        {
            var extensions = UnitOfWork?.ExtensionRepository?.GetAll();
            return extensions?.Select(e => e.ToBllExtension());
        }

        public BllExtension Get(int id)
        {
            var extension = UnitOfWork?.ExtensionRepository?.Get(id);
            return extension?.ToBllExtension();
        }

        public BllExtension GetByPredicate(Expression<Func<BllExtension, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllExtension entity)
        {
            if (entity == null) return;
            UnitOfWork?.ExtensionRepository?.Create(entity.ToDalExtension());
            UnitOfWork?.Commit();
        }

        public void Delete(BllExtension entity)
        {
            if (entity == null) return;
            Delete(entity.Id);
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            UnitOfWork?.ExtensionRepository?.Delete(id);
            UnitOfWork?.Commit();
        }

        public void Update(BllExtension entity)
        {
            if (entity == null) return;
            UnitOfWork?.ExtensionRepository?.Update(entity.ToDalExtension());
            UnitOfWork?.Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}