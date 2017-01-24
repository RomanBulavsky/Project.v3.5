namespace RFoundation.ORM.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Friend
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FriendId { get; set; } // == UserId

        public virtual User User { get; set; }

        public virtual User FriendUser { get; set; }
    }
}
