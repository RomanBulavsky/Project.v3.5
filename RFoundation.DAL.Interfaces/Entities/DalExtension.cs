using System.Collections.Generic;

namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalExtension : IDalEntity
    {
        public int Id { get; set; }
        
        public string ExtensionName { get; set; }

        public ICollection<DalFile> Files { get; set; }
    }
}
