namespace RFoundation.DAL.Interfaces.Entities
{
    public class DalFriend : IDalEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; } // == UserId

        public DalUser User { get; set; }

        public DalUser FriendUser { get; set; }
    }
}
