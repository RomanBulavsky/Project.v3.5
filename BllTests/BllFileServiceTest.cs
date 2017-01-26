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
    public class BllFileServiceTest
    {
        private IFileService userService;

        private IFileService FileService
            => userService ?? (userService = new FileService(new UnitOfWork(new FileStorageDatabaseContext())));


        [TestCase(1, "21")]
        public void GetFileNameById(int fileId, string fileName)
        {
            var file = FileService.Get(fileId);
            Assert.AreEqual(file.Name, fileName);
        }

        [TestCase(1, 1)]
        public void GetFileDataById(int fileId, byte data)
        {
            var file = FileService.Get(fileId);
            var bytes = file.Data[0];
            Assert.AreEqual(bytes, data);
        }

        [TestCase(1, 2)]
        public void GetOwnerIdById(int fileId, int ownerId)
        {
            var file = FileService.Get(fileId);
            var userId = file.UserId;
            Assert.AreEqual(userId, ownerId);
        }

        [Order(1)]
        [TestCase(2,"FileTestName", 1, 20,new byte[]{1,0,1})]
        public void CreateFile(int userId, string fileName, int fileExtensionId, int size, byte[] data)
        {
            var bllFile = new BllFile() {UserId = userId,Name = fileName, ExtensionId = fileExtensionId ,Size = size, Data = data};
            FileService.Create(bllFile);

            var fileFromDb = FileService.GetAll().FirstOrDefault(file => file.Name == bllFile.Name);
            Assert.AreEqual(fileFromDb?.Name, fileName);
        }

        [Order(2)]
        [TestCase("FileTestName", "FileTestNameXXX")]
        public void UpdateFile(string oldName, string newName)
        {
            var fileFromDb =FileService.GetAll().FirstOrDefault(file => file.Name == oldName);
            var id = fileFromDb.Id;
            fileFromDb.Name = newName;
            FileService.Update(fileFromDb);

            var newFile = FileService.Get(id);
            Assert.AreEqual(newFile.Name, newName);
        }

        [Order(3)]
        [TestCase("FileTestNameXXX")]
        public void DeleteFile(string fileName)
        {
            var fileFromDb = FileService.GetAll().FirstOrDefault(file => file.Name == fileName);
            var id = fileFromDb.Id;
            FileService.Delete(id);

            var dalFile = FileService.GetAll().FirstOrDefault(f=>f.Name == fileName);
            Assert.IsNull(dalFile);
        }
    }
}
