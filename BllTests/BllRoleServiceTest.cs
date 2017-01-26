using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.BLL.Implementation.Services;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Implementation;
using RFoundation.ORM.Database;

namespace BllTests
{
    [TestFixture]
    public class BllRoleServiceTest
    {
        private IRoleService userService;

        private IRoleService RoleService
            => userService ?? (userService = new RoleService(new UnitOfWork(new FileStorageDatabaseContext())));


        [TestCase(1, "Admin")]
        public void GetRoleNameById(int roleId, string roleName)
        {
            var role = RoleService.Get(roleId);
            Assert.AreEqual(role.Name, roleName);
        }

        [Order(1)]
        [TestCase("ExtT")]
        public void CreateRole(string roleName)
        {
            var newRole = new BllRole() { Name = roleName };
            RoleService.Create(newRole);

            var roleFromDb = RoleService.GetAll().FirstOrDefault(role => role.Name.Equals(roleName));

            Assert.AreEqual(roleFromDb.Name, roleName);
        }

        [Order(2)]
        [TestCase("ExtT", "ExtX")]
        public void UpdateRole(string oldRoleName, string newRoleName)
        {
            var roleFromDb = RoleService.GetAll().FirstOrDefault(role => role.Name == oldRoleName);
            var id = roleFromDb.Id;
            roleFromDb.Name = newRoleName;
            RoleService.Update(roleFromDb);

            var newRoleFromDb = RoleService.Get(id);
            Assert.AreEqual(newRoleFromDb.Name, newRoleName);
        }

        [Order(3)]
        [TestCase("ExtX")]
        public void DeleteRole(string roleName)
        {
            var roleFromDb = RoleService.GetAll().FirstOrDefault(e => e.Name.Equals(roleName));
            RoleService.Delete(roleFromDb.Id);

            roleFromDb = RoleService.GetAll().FirstOrDefault(role => role.Name.Equals(roleName));

            Assert.IsNull(roleFromDb);
        }
    }
}
