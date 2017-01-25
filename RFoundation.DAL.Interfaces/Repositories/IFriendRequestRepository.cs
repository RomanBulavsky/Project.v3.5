using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.DAL.Interfaces.Repositories
{
    public interface IFriendRequestRepository : IRepository<DalFriendRequest>
    {
        DalFriendRequest Get(DalFriendRequest entity);
    }
}
