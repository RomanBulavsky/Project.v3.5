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
    public class DalUserRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(2, "2")]
        public void TakeLoginById(int userId, string login)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            Assert.AreEqual(user.Login, login);
        }

        [TestCase(2, "2@")]
        public void TakeEmailById(int userId, string email)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            Assert.AreEqual(user.Email, email);
        }

        [TestCase(2, "2")]
        public void TakePasswordById(int userId, string password)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            Assert.AreEqual(user.Password, password);
        }

        [TestCase(2, new int[] {4, 6, 8})]
        public void TakeFriendsById(int userId, int[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var friendsIDsList = user.Friends.Select(u => u.UserId).ToList();

            Assert.AreEqual(friendsIDsList, list.ToList());
        }

        [TestCase(2, new int[] {1, 2, 3, 4, 5})]
        public void TakeUserFilesById(int userId, int[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var filesIdsList = user.Files.Select(f => f.Id).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }

        [TestCase(2, new byte[] {1, 1, 1, 1, 1})]
        public void TakeUserFilesDataById(int userId, byte[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var filesIdsList = user.Files.Select(f => f.Data).ToList();
            var bytes = filesIdsList.Select(f => f[0]).ToList();
            Assert.AreEqual(bytes, list.ToList());
        }

        [TestCase(2, new int[] {1, 2, 3})]
        public void TakeUserSharedFilesById(int userId, int[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var filesIdsList = user.SharedFiles.Select(f => f.FileId).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }

        [TestCase(2, new int[] {8})]
        public void TakeUserReceivedFilesById(int userId, int[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var filesIdsList = user.ReceivedFiles.Select(f => f.FileId).ToList();

            Assert.AreEqual(filesIdsList, list.ToList());
        }
        
        [TestCase("Test@", "Test", "Test")]
        public void CreateUser(string email, string login, string password)
        {
            var dalUser = new DalUser() { Email = email, Login = login, Password = password };
            UnitOfWork.UserRepository.Create(dalUser);
            UnitOfWork.Commit();

            var user = UnitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Email.Equals(email));

            Assert.AreEqual(user.Email, dalUser.Email);

        }

        [TestCase("Test@", "Test@XXX")]
        public void UpdateUser(string oldEmail, string newEmail)
        {
            var userFromDb = UnitOfWork.UserRepository.GetAll().FirstOrDefault(user => user.Email == oldEmail);
            var id = userFromDb.Id;
            userFromDb.Email = newEmail;
            UnitOfWork.UserRepository.Update(userFromDb);
            UnitOfWork.Commit();

            var newUser = UnitOfWork.UserRepository.Get(id);
            Assert.AreEqual(newUser.Email, newEmail);
        }
        [TestCase("Test@XXX", "Test", "Test")]
        public void DeleteUser(string email, string login, string password)
        {
            var user = UnitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Email.Equals(email));
            UnitOfWork.UserRepository.Delete(user.Id);
            UnitOfWork.Commit();

            user = UnitOfWork.UserRepository.GetAll().FirstOrDefault(u => u.Email.Equals(email));
            Assert.IsNull(user);

        }

        //TODO: not important
        /*[TestCase(2, new byte[] {1})]
        public void TakeUserSharedFilesDataById(int userId, byte[] list)
        {
            var user = UnitOfWork.UserRepository.Get(userId);
            var filesIdsList = user.ReceivedFiles.Select(f => f.FileId).ToList();
            var files = UnitOfWork.FileRepository.GetAll().Where(f => filesIdsList.Contains(f.Id));

            var s = files.Select(f => f[0]).ToList();
            Assert.AreEqual(s, list.ToList());
        }*/
    }
}