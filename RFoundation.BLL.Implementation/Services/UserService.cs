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
    public class UserService : IUserService
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public IEnumerable<BllUser> GetAll()
        {
            var users = UnitOfWork?.UserRepository?.GetAll();
            return users?.Select(u => u.ToBllUser());
        }

        public BllUser Get(int id)
        {
            var user = UnitOfWork?.UserRepository?.Get(id);
            return user?.ToBllUser();
        }

        public BllUser Get(string email)
        {
            var user = UnitOfWork?.UserRepository?.Get(email);
            return user?.ToBllUser();
        }

        public BllUser GetByPredicate(Expression<Func<BllUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllUser entity)
        {
            //TODO: throw of not to throw
            if (entity == null) return;
            UnitOfWork?.UserRepository?.Create(entity.ToDalUser());
            UnitOfWork?.Commit();
        }

        public void Delete(BllUser entity)
        {
            if (entity == null) return;
            Delete(entity.Id);
            UnitOfWork?.Commit();
        }

        public void Delete(int id)
        {
            UnitOfWork?.UserRepository?.Delete(id);
            UnitOfWork?.Commit();
        }

        public void Update(BllUser entity)
        {
            if (entity == null) return;
            UnitOfWork?.UserRepository?.Update(entity.ToDalUser());
            UnitOfWork?.Commit();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}