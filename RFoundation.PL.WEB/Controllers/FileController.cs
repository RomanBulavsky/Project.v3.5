using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;

namespace RFoundation.PL.WEB.Controllers
{
    [Authorize]
    public class FileController : Controller
    {
        public IFileService FileService => (IFileService) DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        public IFriendService FriendService
            => (IFriendService) DependencyResolver.Current.GetService(typeof(IFriendService));

        public IFileSharingService FileSharingService
            => (IFileSharingService) DependencyResolver.Current.GetService(typeof(IFileSharingService));

        string Name = Membership.GetUser()?.UserName ?? "Anon";
        private BllUser User => UserService.GetAll().FirstOrDefault(u => u.Login == Name);

        [HttpGet]
        public ActionResult ShareFile(int id)
        {
            ViewBag.fileId = id;
            return View(User.Friends);
        }

        [HttpPost]
        public ActionResult ShareFile(int fileId, int friendId)
        {
            FileSharingService.Create(new BllSharedFile()
            {
                FileId = fileId,
                OwnerId = User.Id,
                RecipientId = friendId
            });
            return View(User.Friends);
        }
    }
}