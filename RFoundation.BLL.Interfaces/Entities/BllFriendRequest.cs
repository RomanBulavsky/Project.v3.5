namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllFriendRequest : IBllEntity
    {
        public int FromUserId { get; set; }
        
        public int ToUserId { get; set; }

        public bool? Confirmed { get; set; }

        public BllUser User { get; set; }

        public BllUser TargetUser { get; set; } //  == ToUserId
    }
}
