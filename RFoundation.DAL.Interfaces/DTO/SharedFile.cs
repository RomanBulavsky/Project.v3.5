using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    class SharedFile
    {
        public int OwnerId { get; set; }
        
        public int RecipientId { get; set; }
        
        public int FileId { get; set; }

        public File File { get; set; }

        public User OwnerUser { get; set; }

        public User RecipientUser { get; set; }
    }
}
