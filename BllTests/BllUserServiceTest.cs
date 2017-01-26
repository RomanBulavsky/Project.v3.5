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
    public class BllUserServiceTest
    {
        private IUserService userService;

        private IUserService UserService
            => userService ?? (userService = new UserService(new UnitOfWork(new FileStorageDatabaseContext())));


        [Test]
        [TestCase(2, "2")]
        public void TakeIds(int userId, string login)
        {
            var user = UserService.Get(userId);
            Assert.AreEqual(user.Login,login);
        }

        [TestCase(2, "2")]
        public void GetLoginById(int userId, string login)
        {
            var user = UserService.Get(userId);
            Assert.AreEqual(user.Login, login);
        }

        [TestCase(2, "2@")]
        public void GetEmailById(int userId, string email)
        {
            var user = UserService.Get(userId);
            Assert.AreEqual(user.Email, email);
        }

        [TestCase(2, "2")]
        public void GetPasswordById(int userId, string password)
        {
            var user = UserService.Get(userId);
            Assert.AreEqual(user.Password, password);
        }

        [TestCase(2, new int[] { 4, 6, 8 })]
        public void GetFriendsById(int userId, int[] list)
        {
            var user = UserService.Get(userId);
            var friendsIDsList = user.Friends.Select(u => u.UserId).ToList();

            Assert.AreEqual(friendsIDsList, list.ToList());
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5 })]
        public void GetUserFilesById(int userId, int[] list)
        {
            var user = UserService.Get(userId);
            var filesIdsList = user.Files.Select(f => f.Id).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }

        [TestCase(2, new byte[] { 1, 1, 1, 1, 1 })]
        public void GetUserFilesDataById(int userId, byte[] list)
        {
            var user = UserService.Get(userId);
            var filesIdsList = user.Files.Select(f => f.Data).ToList();
            var bytes = filesIdsList.Select(f => f[0]).ToList();
            Assert.AreEqual(bytes, list.ToList());
        }

        [TestCase(2, new int[] { 1, 2, 3 })]
        public void GetUserSharedFilesById(int userId, int[] list)
        {
            var user = UserService.Get(userId);
            var filesIdsList = user.SharedFiles.Select(f => f.FileId).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }

        [TestCase(2, new int[] { 8 })]
        public void GetUserReceivedFilesById(int userId, int[] list)
        {
            var user = UserService.Get(userId);
            var filesIdsList = user.ReceivedFiles.Select(f => f.FileId).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }

        [Order(1)]
        [TestCase("Test@", "Test", "Test")]
        public void CreateUser(string email, string login, string password)
        {
            var bllUser = new BllUser() { Email = email, Login = login, Password = password };
            UserService.Create(bllUser);
            

            var user = UserService.GetAll().FirstOrDefault(u => u.Email.Equals(email));

            Assert.AreEqual(user.Email, bllUser.Email);

        }

        [Order(2)]
        [TestCase("Test@", "Test@XXX")]
        public void UpdateUser(string oldEmail, string newEmail)
        {
            var userFromDb = UserService.GetAll().FirstOrDefault(user => user.Email == oldEmail);
            var id = userFromDb.Id;
            userFromDb.Email = newEmail;
            UserService.Update(userFromDb);
            //UnitOfWork.Commit();

            var newUser = UserService.Get(id);
            Assert.AreEqual(newUser.Email, newEmail);
        }

        [Order(3)]
        [TestCase("Test@XXX", "Test", "Test")]
        public void DeleteUser(string email, string login, string password)
        {
            var user = UserService.GetAll().FirstOrDefault(u => u.Email.Equals(email));
            UserService.Delete(user.Id);
            //UnitOfWork.Commit();

            user = UserService.GetAll().FirstOrDefault(u => u.Email.Equals(email));
            Assert.IsNull(user);

        }
    }
}
