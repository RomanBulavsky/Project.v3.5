using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.DAL.Implementation;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace DalTests
{
    [TestFixture]
    public class DalRoleRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(1, "Admin")]
        public void GetRoleNameById(int roleId, string roleName)
        {
            var role = UnitOfWork.RoleRepository.Get(roleId);
            Assert.AreEqual(role.Name, roleName);
        }

        [Order(1)]
        [TestCase("ExtT")]
        public void CreateRole(string roleName)
        {
            var newRole = new DalRole() {Name = roleName};
            UnitOfWork.RoleRepository.Create(newRole);
            UnitOfWork.Commit();  

            var roleFromDb = UnitOfWork.RoleRepository.GetAll().FirstOrDefault(role => role.Name.Equals(roleName));

            Assert.AreEqual(roleFromDb.Name, roleName);
        }

        [Order(2)]
        [TestCase("ExtT", "ExtX")]
        public void UpdateRole(string oldRoleName, string newRoleName)
        {
            var roleFromDb = UnitOfWork.RoleRepository.GetAll().FirstOrDefault(role => role.Name == oldRoleName);
            var id = roleFromDb.Id;
            roleFromDb.Name = newRoleName;
            UnitOfWork.RoleRepository.Update(roleFromDb);
            UnitOfWork.Commit();

            var newRoleFromDb = UnitOfWork.RoleRepository.Get(id);
            Assert.AreEqual(newRoleFromDb.Name, newRoleName);
        }

        [Order(3)]
        [TestCase("ExtX")]
        public void DeleteRole(string roleName)
        {
            var roleFromDb = UnitOfWork.RoleRepository.GetAll().FirstOrDefault(e => e.Name.Equals(roleName));
            UnitOfWork.RoleRepository.Delete(roleFromDb.Id);
            UnitOfWork.Commit();

            roleFromDb = UnitOfWork.RoleRepository.GetAll().FirstOrDefault(role => role.Name.Equals(roleName));

            Assert.IsNull(roleFromDb);
        }

    }
}