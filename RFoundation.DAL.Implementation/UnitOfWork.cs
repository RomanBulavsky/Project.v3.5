using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFoundation.DAL.Implementation.Repositories;
using RFoundation.DAL.Interfaces;
using RFoundation.DAL.Interfaces.Repositories;

namespace RFoundation.DAL.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext Context { get; private set; }

        public IExtensionRepository extensionRepository;
        public IFileRepository fileRepository;
        public IFriendRepository friendRepository;
        public IFriendRequestRepository friendRequestRepository;
        public IRoleRepository roleRepository;
        public ISharedFileRepository sharedFileRepository;
        public IUserRepository userRepository;

        #region Props

        public IExtensionRepository ExtensionRepository
            => extensionRepository ?? (extensionRepository = new ExtensionRepository(Context));

        public IFileRepository FileRepository => fileRepository ?? (fileRepository = new FileRepository(Context));

        public IFriendRepository FriendRepository
            => friendRepository ?? (friendRepository = new FriendRepository(Context));

        public IFriendRequestRepository FriendRequestRepository
            => friendRequestRepository ?? (friendRequestRepository = new FriendRequestRepository(Context));

        public IRoleRepository RoleRepository => roleRepository ?? (roleRepository = new RoleRepository(Context));

        public ISharedFileRepository SharedFileRepository
            => sharedFileRepository ?? (sharedFileRepository = new SharedFileRepository(Context));

        public IUserRepository UserRepository => userRepository ?? (userRepository = new UserRepository(Context));

        #endregion

        public UnitOfWork(DbContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context?.SaveChanges();
        }

        public void Dispose()
            => Context?.Dispose();
    }
}