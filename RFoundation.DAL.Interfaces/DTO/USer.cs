﻿using System;
using System.Collections.Generic;

namespace RFoundation.DAL.Interfaces.DTO
{
    class User
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
        
        public ICollection<File> Files { get; set; }

        public File ProfileImageFile { get; set; }

        public ICollection<FriendRequest> FriendRequests { get; set; }
        
        public ICollection<FriendRequest> FriendOffers { get; set; }
        
        public ICollection<Friend> Friends { get; set; }
        
        public ICollection<Friend> FriendsReserved { get; set; }
        
        public ICollection<SharedFile> SharedFiles { get; set; }
        
        public ICollection<SharedFile> ReceivedFiles { get; set; }
        
        public ICollection<Role> Roles { get; set; }
    }
}