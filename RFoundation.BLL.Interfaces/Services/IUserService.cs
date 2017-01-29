using RFoundation.BLL.Interfaces.Entities;

namespace RFoundation.BLL.Interfaces.Services
{
    public interface IUserService : IService<BllUser>
    {
        BllUser Get(string email);
    }
}