using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    class FriendRequest
    {
        public int FromUserId { get; set; }
        
        public int ToUserId { get; set; }

        public bool? Confirmed { get; set; }

        public User User { get; set; }

        public User TargetUser { get; set; } //  == ToUserId
    }
}
