namespace RFoundation.BLL.Interfaces.Entities
{
    public class BllFriend : IBllEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; } // == UserId

        public BllUser User { get; set; }

        public BllUser FriendUser { get; set; }
    }
}
