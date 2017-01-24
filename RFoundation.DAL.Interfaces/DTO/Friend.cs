using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    class Friend
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; } // == UserId

        public User User { get; set; }

        public User FriendUser { get; set; }
    }
}
