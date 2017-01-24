using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    public class DalExtension : IDalEntity
    {
        public int Id { get; set; }
        
        public string ExtensionName { get; set; }

        public ICollection<DalFile> Files { get; set; }
    }
}
