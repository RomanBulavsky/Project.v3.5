using System;
using System.Collections.Generic;

namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllUser : IBllEntity
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        
        public string Login { get; set; }
        
        public string Password { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public int RoleId { get; set; } = 2;

        public string FirstName { get; set; } = "Bll_Plug";

        public string LastName { get; set; } = "Bll_Plug";

        public DateTime? Birthdate { get; set; }

        public int? ProfileImageFileId { get; set; }

        
        public ICollection<BllFile> Files { get; set; }

        public BllFile ProfileImageFile { get; set; }

        public ICollection<BllFriendRequest> FriendRequests { get; set; }
        
        public ICollection<BllFriendRequest> FriendOffers { get; set; }
        
        public ICollection<BllFriend> Friends { get; set; }
        
        public ICollection<BllFriend> FriendsReserved { get; set; }
        
        public ICollection<BllSharedFile> SharedFiles { get; set; }
        
        public ICollection<BllSharedFile> ReceivedFiles { get; set; }
        
        public ICollection<BllRole> Roles { get; set; }
    }
}
