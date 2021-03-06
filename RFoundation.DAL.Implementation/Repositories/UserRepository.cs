﻿using System;
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
    public class UserRepository : IUserRepository
    {
        private DbContext Context { get; set; }

        public UserRepository(DbContext context)
        {
            Context = context;
        }

        public IEnumerable<DalUser> GetAll()
        {
            var users = Context.Set<User>()?.ToList();
            var dalUsers = users?.Select(u => u.ToDalUser());
            return dalUsers;
        }

        public DalUser Get(int id)
        {
            var user = Context.Set<User>()?.Find(id);
            return user?.ToDalUser();
        }

        public DalUser Get(string email)
        {
            var user = Context.Set<User>()?.FirstOrDefault(u=>u.Email == email);
            return user?.ToDalUser();
        }

        public DalUser GetByPredicate(Expression<Func<DalUser, bool>> f)
        {
            throw new NotImplementedException();
        }

        public void Create(DalUser entity)
        {
            var ormUser = entity?.ToOrmUser();
            if(ormUser == null) return;
            Context.Set<User>()?.Add(ormUser);
        }

        public void Delete(DalUser entity)
        {
            if (entity == null) return;
            Delete(entity.Id);
        }

        public void Delete(int id)
        {
            var user = Context.Set<User>()?.Find(id);
            if (user == null) return;
            Context.Set<User>().Remove(user);
        }

        public void Update(DalUser entity)
        {
            if (entity == null) return;
            var ormUser = Context.Set<User>()?.Find(entity.Id);
            if (ormUser == null) return;
            ormUser.Email = entity.Email;
            ormUser.Login = entity.Login;
            ormUser.Password = entity.Password;
            ormUser.LastUpdateDate = DateTime.Now;
            ormUser.RoleId = entity.RoleId;
            ormUser.FirstName = entity.FirstName;
            ormUser.LastName = entity.LastName;
            ormUser.Birthdate = entity.Birthdate;
            ormUser.ProfileImageFileId = entity.ProfileImageFileId;
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}