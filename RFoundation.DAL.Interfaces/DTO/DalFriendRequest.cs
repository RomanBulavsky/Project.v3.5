using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    public class DalFriendRequest : IDalEntity
    {
        public int FromUserId { get; set; }
        
        public int ToUserId { get; set; }

        public bool? Confirmed { get; set; }

        public DalUser User { get; set; }

        public DalUser TargetUser { get; set; } //  == ToUserId
    }
}
