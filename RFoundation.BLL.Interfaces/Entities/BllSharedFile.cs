namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllSharedFile : IBllEntity
    {
        public int OwnerId { get; set; }
        
        public int RecipientId { get; set; }
        
        public int FileId { get; set; }

        public BllFile File { get; set; }

        public BllUser OwnerUser { get; set; }

        public BllUser RecipientUser { get; set; }
    }
}
