using RFoundation.BLL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.BLL.Implementation.Mappers
{
    static class BllToDalMapper
    {
        public static DalUser ToDalUser(this BllUser userEntity)
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
                ProfileImageFileId = userEntity.ProfileImageFileId
            };
        }
        public static DalFile ToDalFile(this BllFile fileEntity)
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

        public static DalExtension ToDalExtension(this BllExtension extensionEntity)
        {
            return new DalExtension()
            {
                Id = extensionEntity.Id,
                ExtensionName = extensionEntity.ExtensionName
            };
        }

        public static DalFriend ToDalFriend(BllFriend friendEntity)
        {
            return new DalFriend() {
                Id = friendEntity.Id,
                FriendId = friendEntity.FriendId,
                UserId = friendEntity.UserId
            };
        }

        public static DalFriendRequest ToDalFriendRequest(this BllFriendRequest friendRequestEntity)
        {
            return new DalFriendRequest()
            {
                FromUserId = friendRequestEntity.FromUserId,
                ToUserId = friendRequestEntity.ToUserId,
                Confirmed = friendRequestEntity.Confirmed
            };
        }

        public static DalRole ToDalRole(this BllRole roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        public static DalSharedFile ToDalSharedFile(this BllSharedFile sharedFileEntity)
        {
            return new DalSharedFile()
            {
                FileId = sharedFileEntity.FileId,
                OwnerId = sharedFileEntity.OwnerId,
                RecipientId = sharedFileEntity.RecipientId
            };
        }
    }
}
