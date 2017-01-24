using System;
using System.Collections.Generic;

namespace RFoundation.DAL.Interfaces.DTO
{
    public class DalUser : IDalEntity
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public int RoleId { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public int? ProfileImageFileId { get; set; }

        //TODO: Main Navigation
        
        public ICollection<DalFile> Files { get; set; }

        public DalFile ProfileImageFile { get; set; }

        public ICollection<DalFriendRequest> FriendRequests { get; set; }
        
        public ICollection<DalFriendRequest> FriendOffers { get; set; }
        
        public ICollection<DalFriend> Friends { get; set; }
        
        public ICollection<DalFriend> FriendsReserved { get; set; }
        
        public ICollection<DalSharedFile> SharedFiles { get; set; }
        
        public ICollection<DalSharedFile> ReceivedFiles { get; set; }
        
        public ICollection<DalRole> Roles { get; set; }
    }
}
