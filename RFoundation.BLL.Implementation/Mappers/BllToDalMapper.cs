using RFoundation.BLL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.BLL.Implementation.Mappers
{
    static class BllToDalMapper
    {
        public static DalUser ToDalUser(this BllUser userEntity)
        {
            return new DalUser()
            {

            };
        }
        public static DalFile ToDalFile(this BllFile fileEntity)
        {
            return new DalFile()
            {

            };
        }
    }
}
