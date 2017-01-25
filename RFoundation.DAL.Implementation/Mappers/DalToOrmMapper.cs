using RFoundation.DAL.Interfaces.Entities;
using RFoundation.ORM.Database;

namespace RFoundation.DAL.Implementation.Mappers
{
    static class DalToOrmMapper
    {
        public static User ToDalUser(this DalUser userEntity)
        {
            return new User()
            {

            };
        }
        public static File ToDalFile(this DalFile fileEntity)
        {
            return new File()
            {

            };
        }
    }
}
