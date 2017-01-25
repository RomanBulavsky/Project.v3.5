﻿using System;
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

        [TestCase(1, "21")]
        public void TakeFileNameById(int fileId, string fileName)
        {
            var file = UnitOfWork.FileRepository.Get(fileId);
            Assert.AreEqual(file.Name, fileName);
        }

        [TestCase(1, 1)]
        public void TakeFileDataById(int fileId, byte data)
        {
            var file = UnitOfWork.FileRepository.Get(fileId);
            var bytes = file.Data[0];
            Assert.AreEqual(bytes, data);
        }

        [TestCase(1, 2)]
        public void TakeOwnerIdById(int fileId, int ownerId)
        {
            var file = UnitOfWork.FileRepository.Get(fileId);
            var owner = file.User;//TODO: we don't mapped it.
            var userId = file.UserId;
            Assert.AreEqual(userId, ownerId);
        }

        [TestCase(2,"FileTestName", 1, 20,new byte[]{1,0,1})]
        public void CreateUser(int userId, string fileName, int fileExtensionId, int size, byte[] data)
        {
            var dalFile = new DalFile() {UserId = userId,Name = fileName, ExtensionId = fileExtensionId ,Size = size, Data = data};
            UnitOfWork.FileRepository.Create(dalFile);
            UnitOfWork.Commit();

            var fileFromDb = UnitOfWork.FileRepository.GetAll().FirstOrDefault(file => file.Name == dalFile.Name);
            Assert.AreEqual(fileFromDb?.Name, fileName);
        }

        [TestCase("FileTestName", "FileTestNameXXX")]
        public void UpdateFile(string oldName, string newName)
        {
            var fileFromDb = UnitOfWork.FileRepository.GetAll().FirstOrDefault(file => file.Name == oldName);
            var id = fileFromDb.Id;
            fileFromDb.Name = newName;
            UnitOfWork.FileRepository.Update(fileFromDb);
            UnitOfWork.Commit();

            var newFile = UnitOfWork.FileRepository.Get(id);
            Assert.AreEqual(newFile.Name, newName);
        }

        [TestCase("FileTestNameXXX")]
        public void DeleteFile(string fileName)
        {
            var fileFromDb = UnitOfWork.FileRepository.GetAll().FirstOrDefault(file => file.Name == fileName);
            var id = fileFromDb.Id;
            UnitOfWork.FileRepository.Delete(id);
            UnitOfWork.Commit();

            var delFile = UnitOfWork.FileRepository.GetAll().FirstOrDefault(f=>f.Name == fileName);
            Assert.IsNull(delFile);
        }

    }
}