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
    public class BllFileSharingServiceTest
    {
        private IFileSharingService userService;

        private IFileSharingService FileSharingService
            => userService ?? (userService = new FileSharingService(new UnitOfWork(new FileStorageDatabaseContext())));


        [TestCase(1, 2, 4)]
        public void GetSharedFileEntity(int fileId, int ownerId, int recipientId)
        {
            var sharedFile =
                FileSharingService.Get(new BllSharedFile()
                {
                    FileId = fileId,
                    OwnerId = ownerId,
                    RecipientId = recipientId
                });
            Assert.AreEqual(sharedFile.OwnerId, ownerId);
        }

        [Order(1)]
        [TestCase(2, 3, 1)]
        public void CreateSharedFile(int ownerId, int recipientId, int fileId)
        {
            var sharedFile = new BllSharedFile() { FileId = fileId, OwnerId = ownerId, RecipientId = recipientId };
            FileSharingService.Create(sharedFile);

            var sharedFileFromDb =
                FileSharingService.GetAll()
                    .FirstOrDefault(
                        sf => sf.FileId == sharedFile.FileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);
            Assert.AreEqual(sharedFileFromDb?.OwnerId, ownerId);
        }

        [Order(2)]
        [TestCase(2, 3, 1)]
        public void DeleteSharedFile(int ownerId, int recipientId, int fileId)
        {
            var fileFromDb =
                FileSharingService.GetAll()
                    .FirstOrDefault(sf => sf.FileId == fileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);
            FileSharingService.Delete(fileFromDb);

            var dalSharedFile =
                FileSharingService.GetAll()
                    .FirstOrDefault(sf => sf.FileId == fileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);
            Assert.IsNull(dalSharedFile);
        }
    }
}
