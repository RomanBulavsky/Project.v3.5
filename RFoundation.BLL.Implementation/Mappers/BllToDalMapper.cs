using RFoundation.BLL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.BLL.Implementation.Mappers
{
    /// <summary>
    /// Class that provides extension mapper methods 
    /// from <see cref="RFoundation.BLL.Interfaces.Entities"/> entities 
    /// to <see cref="RFoundation.DAL.Interfaces.Entities"/> entities
    /// </summary>
    /// <seealso cref="RFoundation.DAL"/>
    /// <seealso cref="RFoundation.BLL"/>
    static class BllToDalMapper
    {
        /// <summary>
        /// Mapping <see cref="BllUser"/> entity to <see cref="DalUser"/> entity.
        /// </summary>
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

        /// <summary>
        /// Mapping <see cref="BllFile"/> entity to <see cref="DalFile"/> entity.
        /// </summary>
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

        /// <summary>
        /// Mapping <see cref="BllExtension"/> entity to <see cref="DalExtension"/> entity.
        /// </summary>
        public static DalExtension ToDalExtension(this BllExtension extensionEntity)
        {
            return new DalExtension()
            {
                Id = extensionEntity.Id,
                ExtensionName = extensionEntity.ExtensionName
            };
        }

        /// <summary>
        /// Mapping <see cref="BllFriend"/> entity to <see cref="DalFriend"/> entity.
        /// </summary>
        public static DalFriend ToDalFriend(this BllFriend friendEntity)
        {
            return new DalFriend()
            {
                Id = friendEntity.Id,
                FriendId = friendEntity.FriendId,
                UserId = friendEntity.UserId
            };
        }

        /// <summary>
        /// Mapping <see cref="BllFriendRequest"/> entity to <see cref="DalFriendRequest"/> entity.
        /// </summary>
        public static DalFriendRequest ToDalFriendRequest(this BllFriendRequest friendRequestEntity)
        {
            return new DalFriendRequest()
            {
                FromUserId = friendRequestEntity.FromUserId,
                ToUserId = friendRequestEntity.ToUserId,
                Confirmed = friendRequestEntity.Confirmed
            };
        }

        /// <summary>
        /// Mapping <see cref="BllRole"/> entity to <see cref="DalRole"/> entity.
        /// </summary>
        public static DalRole ToDalRole(this BllRole roleEntity)
        {
            return new DalRole()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name
            };
        }

        /// <summary>
        /// Mapping <see cref="BllSharedFile"/> entity to <see cref="DalSharedFile"/> entity.
        /// </summary>
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