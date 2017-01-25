using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            throw new NotImplementedException();
        }

        public BllUser Get(int id)
        {
            throw new NotImplementedException();
        }

        public BllUser GetByPredicate(Expression<Func<BllUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(BllUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(BllUser entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(BllUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}