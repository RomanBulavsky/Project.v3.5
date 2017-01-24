using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    public class DalFriend : IDalEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; } // == UserId

        public DalUser User { get; set; }

        public DalUser FriendUser { get; set; }
    }
}
