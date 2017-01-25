using System.Collections.Generic;

namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllExtension : IBllEntity
    {
        public int Id { get; set; }
        
        public string ExtensionName { get; set; }

        public ICollection<BllFile> Files { get; set; }
    }
}
