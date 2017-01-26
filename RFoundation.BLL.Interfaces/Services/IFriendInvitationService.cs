using RFoundation.BLL.Interfaces.Entities;

namespace RFoundation.BLL.Interfaces.Services
{
    public interface IFriendInvitationService : IService<BllFriendRequest>
    {
        BllFriendRequest Get(BllFriendRequest entity);
    }
}
