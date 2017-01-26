using System;
using System.Collections.Generic;

namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllFile : IBllEntity
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


        public BllExtension Extension { get; set; }

        public ICollection<BllFile> ChildFiles { get; set; }

        public BllFile ParentFile { get; set; }

        public BllUser User { get; set; }

        public ICollection<BllSharedFile> SharedFiles { get; set; }

        public ICollection<BllUser> Users { get; set; }
    }
}
