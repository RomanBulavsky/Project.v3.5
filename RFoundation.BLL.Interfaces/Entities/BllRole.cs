using System.Collections.Generic;

namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllRole : IBllEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BllUser> Users { get; set; }
    }
}
