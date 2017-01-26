using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RFoundation.DAL.Implementation;
using RFoundation.DAL.Implementation.Mappers;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace DalTests
{
    [TestFixture]
    public class DalSharedFileRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(1, 2, 4)]
        public void GetSharedFileEntity(int fileId, int ownerId, int recipientId)
        {
            var sharedFile =
                UnitOfWork.SharedFileRepository.Get(new DalSharedFile()
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
            var sharedFile = new DalSharedFile() {FileId = fileId, OwnerId = ownerId, RecipientId = recipientId};
            UnitOfWork.SharedFileRepository.Create(sharedFile);
            UnitOfWork.Commit();

            var sharedFileFromDb =
                UnitOfWork.SharedFileRepository.GetAll()
                    .FirstOrDefault(
                        sf => sf.FileId == sharedFile.FileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);
            Assert.AreEqual(sharedFileFromDb?.OwnerId, ownerId);
        }

        [Order(2)]
        [TestCase(2, 3, 1)]
        public void DeleteSharedFile(int ownerId, int recipientId, int fileId)
        {
            var fileFromDb =
                UnitOfWork.SharedFileRepository.GetAll()
                    .FirstOrDefault(sf => sf.FileId == fileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);

            UnitOfWork.SharedFileRepository.Delete(fileFromDb);
            UnitOfWork.Commit();

            var dalSharedFile =
                UnitOfWork.SharedFileRepository.GetAll()
                    .FirstOrDefault(sf => sf.FileId == fileId && sf.RecipientId == recipientId && sf.OwnerId == ownerId);
            Assert.IsNull(dalSharedFile);
        }
    }
}