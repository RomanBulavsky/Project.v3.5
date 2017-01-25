using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Mappers
{
    static class DalToOrmMapper
    {
        public static User ToOrmUser(this DalUser userEntity)
        {
            return new User()
            {
                Id = userEntity.Id,
                Email = userEntity.Email,
                Login = userEntity.Login,
                Password = userEntity.Password,
                CreationDate = userEntity.CreationDate,
                LastUpdateDate = userEntity.LastUpdateDate,
                RoleId = userEntity.RoleId,
                FirstName = userEntity.FirstName,
                LastName = userEntity.LastName,
                Birthdate = userEntity.Birthdate,
                ProfileImageFileId = userEntity.ProfileImageFileId
                /* TODO: for deleting,
                Friends = userEntity.Friends.Select(u => u.ToDalFriend()).ToList(),
                Files = userEntity.Files.Select(f => f.ToDalFile()).ToList(),
                ReceivedFiles = userEntity.ReceivedFiles.Select(rf => rf.ToDalSharedFile()).ToList(),
                SharedFiles = userEntity.SharedFiles.Select(sf => sf.ToDalSharedFile()).ToList()*/
            };
        }

        public static File ToOrmFile(this DalFile fileEntity)
        {
            return new File()
            {
                Id = fileEntity.Id,
                UserId = fileEntity.UserId,
                Name = fileEntity.Name,
                ExtensionId = fileEntity.ExtensionId,
                Size = fileEntity.Size,
                Data = fileEntity.Data,
                UploadDate = fileEntity.UploadDate,
                IsProfileImage = fileEntity.IsProfileImage,
                Banned = fileEntity.Banned,
                IsFolder = fileEntity.IsFolder,
                ParentFileFolderId = fileEntity.ParentFileFolderId
            };
        }
    }
}