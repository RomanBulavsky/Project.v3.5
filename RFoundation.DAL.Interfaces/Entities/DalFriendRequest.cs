namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalFriendRequest : IDalEntity
    {
        public int FromUserId { get; set; }
        
        public int ToUserId { get; set; }

        public bool? Confirmed { get; set; }

        public DalUser User { get; set; }

        public DalUser TargetUser { get; set; } //  == ToUserId
    }
}
