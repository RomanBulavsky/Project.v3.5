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
    public class BllExtensionServiceTest
    {
        private IExtensionService userService;

        private IExtensionService ExtensionService
            => userService ?? (userService = new ExtensionService(new UnitOfWork(new FileStorageDatabaseContext())));

        [TestCase(1, "txt")]
        public void GetById(int extensionId, string extName)
        {
            var extension = ExtensionService.Get(extensionId);
            Assert.AreEqual(extension.ExtensionName, extName);
        }

        [Order(1)]
        [TestCase("ExtT")]
        public void CreateExtension(string extName)
        {
            var extension = new BllExtension() { ExtensionName = extName };
            ExtensionService.Create(extension);

            var extFromDb = ExtensionService.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));

            Assert.AreEqual(extFromDb.ExtensionName, extName);
        }

        [Order(2)]
        [TestCase("ExtT", "ExtX")]
        public void UpdateExtension(string oldExt, string newExt)
        {
            var extFromDb = ExtensionService.GetAll().FirstOrDefault(ext => ext.ExtensionName == oldExt);
            var id = extFromDb.Id;
            extFromDb.ExtensionName = newExt;
            ExtensionService.Update(extFromDb);

            var newExtensionFromDb = ExtensionService.Get(id);
            Assert.AreEqual(newExtensionFromDb.ExtensionName, newExt);
        }

        [Order(3)]
        [TestCase("ExtX")]
        public void DeleteExtension(string extName)
        {
            var extFromDb = ExtensionService.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));
            ExtensionService.Delete(extFromDb.Id);

            extFromDb = ExtensionService.GetAll().FirstOrDefault(e => e.ExtensionName.Equals(extName));
            Assert.IsNull(extFromDb);
        }
    }
}
