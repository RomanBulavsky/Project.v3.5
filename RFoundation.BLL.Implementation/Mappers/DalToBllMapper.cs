using RFoundation.BLL.Interfaces.Entities;
using RFoundation.DAL.Interfaces.Entities;

namespace RFoundation.BLL.Implementation.Mappers
{
    static class DalToBllMapper
    {
        public static BllUser ToBllUser(this DalUser dalUser)
        {
            return new BllUser()//TODO:Split ??
            {



            };
        }
        public static BllFile ToBllFile(this DalFile dalFile)
        {
            return new BllFile()
            {

            };
        }
    }
}
