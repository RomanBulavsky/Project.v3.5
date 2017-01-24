namespace RFoundation.ORM.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FileStorageDatabaseContext : DbContext
    {
        public FileStorageDatabaseContext()
            : base("name=FileStorageDatabaseConnectionString")
        {
        }

        public virtual DbSet<Extension> Extensions { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FriendRequest> FriendRequests { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SharedFile> SharedFiles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Extension>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.Extension)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<File>()
                .HasMany(e => e.Files1)
                .WithOptional(e => e.File1)
                .HasForeignKey(e => e.ParentFileFolderId);

            modelBuilder.Entity<File>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.File)
                .HasForeignKey(e => e.ProfileImageFileId);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles)
                .Map(m => m.ToTable("UsersRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Files)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendRequests)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FromUserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendOffers)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ToUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.FriendId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendsReserved)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SharedFiles)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ReceivedFiles)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.RecipientId)
                .WillCascadeOnDelete(false);
        }
    }
}
