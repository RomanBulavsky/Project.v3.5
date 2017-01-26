using System.Linq;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.BLL.Implementation.Mappers
{
    static class DalToBllMapper
    {
        public static BllUser ToBllUser(this DalUser userEntity)
        {
            return new BllUser()
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
                ProfileImageFileId = userEntity.ProfileImageFileId,
                Friends = userEntity.Friends.Select(u => u.ToBllFriend()).ToList(),
                Files = userEntity.Files.Select(f => f.ToBllFile()).ToList(),
                ReceivedFiles = userEntity.ReceivedFiles.Select(rf => rf.ToBllSharedFileFile()).ToList(),
                SharedFiles = userEntity.SharedFiles.Select(sf => sf.ToBllSharedFileFile()).ToList()
            };
        }

        public static BllFile ToBllFile(this DalFile fileEntity)
        {
            return new BllFile()
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

        public static BllFriend ToBllFriend(this DalFriend friendEntity)
        {
            return new BllFriend()
            {
                Id = friendEntity.Id,
                FriendId = friendEntity.FriendId,
                UserId = friendEntity.UserId
            };
        }

        public static BllSharedFile ToBllSharedFileFile(this DalSharedFile sharedFileEntity)
        {
            return new BllSharedFile()
            {
                OwnerId = sharedFileEntity.OwnerId,
                RecipientId = sharedFileEntity.RecipientId,
                FileId = sharedFileEntity.FileId
            };
        }

        public static BllExtension ToBllExtension(this DalExtension extensionEntity)
        {
            return new BllExtension()
            {
                Id = extensionEntity.Id,
                ExtensionName = extensionEntity.ExtensionName
            };
        }

        public static BllFriendRequest ToBllFriendRequest(this DalFriendRequest friendRequestEntity)
        {
            return new BllFriendRequest()
            {
                FromUserId = friendRequestEntity.FromUserId,
                ToUserId = friendRequestEntity.ToUserId,
                Confirmed = friendRequestEntity.Confirmed
            };
        }

        public static BllRole ToBllRole(this DalRole roleEntity)
        {
            return new BllRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Users = roleEntity.Users.Select(u => u.ToBllUser()).ToList()
            };
        }

    }
}