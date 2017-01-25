using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFoundation.DAL.Interfaces.Repositories;

namespace RFoundation.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IExtensionRepository ExtensionRepository { get; }
        IFileRepository FileRepository { get; }
        IFriendRepository FriendRepository { get; }
        IFriendRequestRepository FriendRequestRepository { get; }
        IRoleRepository RoleRepository { get; }
        ISharedFileRepository SharedFileRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
