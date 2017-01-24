using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    class File
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        
        public string Name { get; set; }

        public int ExtensionId { get; set; }

        public int Size { get; set; }
        
        public byte[] Data { get; set; }

        public DateTime UploadDate { get; set; }

        public bool IsProfileImage { get; set; }

        public bool Banned { get; set; }

        public bool? IsFolder { get; set; }

        public int? ParentFileFolderId { get; set; }

        // TODO: Main Navigation

        public Extension Extension { get; set; }

        public ICollection<File> ChildFiles { get; set; }

        public File ParentFile { get; set; }

        public User User { get; set; }

        public ICollection<SharedFile> SharedFiles { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
