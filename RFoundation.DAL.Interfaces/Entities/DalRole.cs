using System.Collections.Generic;

namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalRole : IDalEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DalUser> Users { get; set; }
    }
}
