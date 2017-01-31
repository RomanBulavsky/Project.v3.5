using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.PL.WEB.Models;

namespace PL.WEB.v4.Infrastructure
{
    public static class ViewMappers
    {
        public static FileViewModel ToMvcFile(this BllFile fileEntity)
        {
            return new FileViewModel()
            {
                Id = fileEntity.Id,
                Name = fileEntity.Name,
                UserId = fileEntity.UserId,
                Size = fileEntity.Size,
                Extension = fileEntity.Extension?.ExtensionName ?? "txt",
                Received = false,
                UploadDate = fileEntity.UploadDate
            };
        }
        public static UserViewModel ToMvcUser(this BllUser userEntity)
        {
            return new UserViewModel()
            {
                Birthdate = userEntity.Birthdate,
                LastName = userEntity.LastName,
                FirstName = userEntity.FirstName
            };
        }
        
        
    }
}