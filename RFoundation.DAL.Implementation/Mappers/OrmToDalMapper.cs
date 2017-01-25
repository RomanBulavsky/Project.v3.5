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
                ReceivedFiles = userEntity.ReceivedFiles.Select(rf=>rf.ToDalSharedFile()).ToList()

            };
        }
        public static DalFile ToDalFile(this File fileEntity)
        {
            return new DalFile()
            {

            };
        }

        public static DalFriend ToDalFriend(this Friend friendEntity)
        {
            return new DalFriend();
        }
        public static DalSharedFile ToDalSharedFile(this SharedFile friendEntity)
        {
            return new DalSharedFile();
        }
    }
}
