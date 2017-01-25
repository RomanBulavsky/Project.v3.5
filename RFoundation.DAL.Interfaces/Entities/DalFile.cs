using System;
using System.Collections.Generic;

namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalFile : IDalEntity
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

        public DalExtension Extension { get; set; }

        public ICollection<DalFile> ChildFiles { get; set; }

        public DalFile ParentFile { get; set; }

        public DalUser User { get; set; }

        public ICollection<DalSharedFile> SharedFiles { get; set; }

        public ICollection<DalUser> Users { get; set; }
    }
}
