using System.Linq;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Mappers
{
    public static class DalToOrmMapper
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

        public static Extension ToOrmExtension(this DalExtension extensionEntity)
        {
            return new Extension()
            {
                Id = extensionEntity.Id,
                ExtensionName = extensionEntity.ExtensionName    
            };
        }
        public static Friend ToOrmFriend(this DalFriend friendEntity)
        {
            return new Friend()
            {
                Id = friendEntity.Id,
                FriendId = friendEntity.FriendId,
                UserId = friendEntity.UserId
            };
        }
        public static FriendRequest ToOrmFriendRequest(this DalFriendRequest friendRequestEntity)
        {
            return new FriendRequest()
            {
                FromUserId = friendRequestEntity.FromUserId,
                ToUserId = friendRequestEntity.ToUserId,
                Confirmed = friendRequestEntity.Confirmed
            };
        }
        public static Role ToOrmRole(this DalRole roleEntity)
        {
            return new Role()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Users = roleEntity.Users.Select(u=>u.ToOrmUser()).ToList()
            };
        }
        public static SharedFile ToOrmSharedFile(this DalSharedFile sharedFileEntity)
        {
            return new SharedFile()
            {
                FileId = sharedFileEntity.FileId,
                OwnerId = sharedFileEntity.OwnerId,
                RecipientId = sharedFileEntity.RecipientId 
            };
        }
    }
}