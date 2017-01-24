using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    class Extension
    {
        public int Id { get; set; }
        
        public string ExtensionName { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
