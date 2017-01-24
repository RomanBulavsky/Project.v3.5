using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFoundation.DAL.Interfaces.DTO
{
    public class DalRole : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DalUser> Users { get; set; }
    }
}
