using System.Data.Entity;
using Ninject;
using Ninject.Web.Common;
using RFoundation.BLL.Implementation.Services;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.DAL.Implementation;
using RFoundation.DAL.Interfaces;
using RFoundation.ORM.Database;

namespace NinjectConfigurator
{
    public static class DependencyResolver
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        /// <summary>
        /// this method kljdlkdfjlkdfjlkdsjf
        /// </summary>
        /// <param name="kernel">asdjlkkhaskjhsa</param>
        /// <param name="isWeb">aksjmhaskjhsa</param>
        private static void Configure(IKernel kernel, bool isWeb)
        {
            if (isWeb)
            {
                kernel.Bind<DbContext>().To<FileStorageDatabaseContext>().InRequestScope();
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<IExtensionService>().To<ExtensionService>().InRequestScope();
                kernel.Bind<IFileService>().To<FileService>().InRequestScope();
                kernel.Bind<IFileSharingService>().To<FileSharingService>().InRequestScope();
                kernel.Bind<IFriendInvitationService>().To<FriendInvitationService>().InRequestScope();
                kernel.Bind<IFriendService>().To<FriendService>().InRequestScope();
                kernel.Bind<IRoleService>().To<RoleService>().InRequestScope();
                kernel.Bind<IUserService>().To<UserService>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<FileStorageDatabaseContext>().InSingletonScope();
                kernel.Bind<IUserService>().To<UserService>();
                kernel.Bind<IFileService>().To<FileService>();
            }
        }
    }
}