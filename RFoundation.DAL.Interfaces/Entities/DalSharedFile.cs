namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalSharedFile : IDalEntity
    {
        public int OwnerId { get; set; }
        
        public int RecipientId { get; set; }
        
        public int FileId { get; set; }

        public DalFile File { get; set; }

        public DalUser OwnerUser { get; set; }

        public DalUser RecipientUser { get; set; }
    }
}
