using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using PL.WEB.v4.Infrastructure;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;

namespace PL.WEB.v4.Controllers
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
        private BllUser CurrentUser => UserService?.Get(Membership.GetUser()?.Email);

        [HttpGet]
        public ActionResult ShareFile(int fileId)
        {
            //TempData["fileId"] = fileId;
            ViewBag.fileId = fileId;
            var friendIds = CurrentUser?.Friends.Select(f=>f.UserId);
            if (friendIds == null) return View();
            
            var users = new List<BllUser>();

            foreach (var id in friendIds)
            {
                var user = UserService.Get(id);
                users.Add(user);
            }

            return View(users);
        }

        //TODO: POST
        [HttpGet]
        public ActionResult ShareFile2(int friendId, int fileId)
        {
            var x = ViewBag.fileId;
            FileSharingService.Create(new BllSharedFile()
            {
                FileId = fileId,//(int)TempData["fileId"],
                OwnerId = CurrentUser.Id,
                RecipientId = friendId
            });
            return RedirectToAction("Index","Home");
        }
    }
}