using System.Linq;
using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Mappers
{
    public static class OrmToDalMapper
    {
        public static DalUser ToDalUser(this User userEntity)
        {
            return new DalUser()
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
                Friends = userEntity.Friends.Select(u=>u.ToDalFriend()).ToList(),
                Files = userEntity.Files.Select(f=>f.ToDalFile()).ToList(),
                ReceivedFiles = userEntity.ReceivedFiles.Select(rf=>rf.ToDalSharedFile()).ToList(),
                SharedFiles = userEntity.SharedFiles.Select(sf=>sf.ToDalSharedFile()).ToList()

            };
        }
        public static DalFile ToDalFile(this File fileEntity)
        {
            return new DalFile()
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
        public static DalFriend ToDalFriend(this Friend friendEntity)
        {
            return new DalFriend()
            {
                Id = friendEntity.Id,
                FriendId = friendEntity.FriendId,
                UserId = friendEntity.UserId
            };
        }
        public static DalSharedFile ToDalSharedFile(this SharedFile sharedFileEntity)
        {
            return new DalSharedFile()
            {
                OwnerId = sharedFileEntity.OwnerId,
                RecipientId = sharedFileEntity.RecipientId,
                FileId = sharedFileEntity.FileId
            };
        }
        public static DalExtension ToDalExtension(this Extension extensionEntity)
        {
            return new DalExtension()
            {
                Id = extensionEntity.Id,
                ExtensionName = extensionEntity.ExtensionName
            };
        }
        public static DalFriendRequest ToDalFriendRequest(this FriendRequest friendRequestEntity)
        {
            return new DalFriendRequest()
            {
                FromUserId = friendRequestEntity.FromUserId,
                ToUserId = friendRequestEntity.ToUserId,
                Confirmed = friendRequestEntity.Confirmed
            };
        }
        public static DalRole ToDalRole(this Role roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Users = roleEntity.Users.Select(u=>u.ToDalUser()).ToList()
            };
        }
    }
}
