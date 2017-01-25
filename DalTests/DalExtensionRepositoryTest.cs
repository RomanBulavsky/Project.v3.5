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
    public class DalExtensionRepositoryTest
    {
        private IUnitOfWork unitOfWork;

        private IUnitOfWork UnitOfWork
            => unitOfWork ?? (unitOfWork = new UnitOfWork(new FileStorageDatabaseContext()));

        [TestCase(1, "txt")]
        public void GetById(int extensionId, string extName)
        {
            var extension = UnitOfWork.ExtensionRepository.Get(extensionId);
            Assert.AreEqual(extension.ExtensionName, extName);
        }

        [Order(1)]
        [TestCase("ExtT")]
        public void CreateExtension(string extName)
        {
            var extension = new DalExtension() {ExtensionName = extName};
            UnitOfWork.ExtensionRepository.Create(extension);
            UnitOfWork.Commit();

            var extFromDb = UnitOfWork.ExtensionRepository.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));

            Assert.AreEqual(extFromDb.ExtensionName, extName);
        }

        [Order(2)]
        [TestCase("ExtT", "ExtX")]
        public void UpdateExtension(string oldExt, string newExt)
        {
            var extFromDb = UnitOfWork.ExtensionRepository.GetAll().FirstOrDefault(ext => ext.ExtensionName == oldExt);
            var id = extFromDb.Id;
            extFromDb.ExtensionName = newExt;
            UnitOfWork.ExtensionRepository.Update(extFromDb);
            UnitOfWork.Commit();

            var newExtensionFromDb = UnitOfWork.ExtensionRepository.Get(id);
            Assert.AreEqual(newExtensionFromDb.ExtensionName, newExt);
        }

        [Order(3)]
        [TestCase("ExtX")]
        public void DeleteExtension(string extName)
        {
            var extFromDb = UnitOfWork.ExtensionRepository.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));
            UnitOfWork.ExtensionRepository.Delete(extFromDb.Id);
            UnitOfWork.Commit();

            extFromDb = UnitOfWork.ExtensionRepository.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));
            Assert.IsNull(extFromDb);
        }
    }
}