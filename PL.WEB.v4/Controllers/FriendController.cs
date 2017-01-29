using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;

namespace PL.WEB.v4.Controllers
{
    public class FriendController : Controller
    {
        public IFileService FileService => (IFileService) DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));
        string Name = Membership.GetUser()?.UserName ?? "Anon";
        private int Id => UserService.GetAll().FirstOrDefault(u => u.Login == Name).Id;
        private BllUser User => UserService.GetAll().FirstOrDefault(u => u.Login == Name);

        public IFriendService FriendService
            => (IFriendService) DependencyResolver.Current.GetService(typeof(IFriendService));

        public ActionResult FriendList()
        {
            var u = Membership.GetUser();

            return View(User.Friends);
        }

        public ActionResult FriendOfferList()
        {
            var u = Membership.GetUser();

            return PartialView(User.FriendRequests);
        }
        //TODO:POST
        public void AddToFriend(int friendId)
        {
            var friend = UserService.Get(friendId);
            if (friend.Friends == null)
                friend.Friends = new List<BllFriend>();
            if (User.Friends == null)
                User.Friends = new List<BllFriend>();
            if (User.Friends != null && friend.Friends != null)
            {
                FriendService.Create(new BllFriend() {FriendId = friendId, UserId = User.Id});
                FriendService.Create(new BllFriend() {FriendId = User.Id, UserId = friend.Id});
            }
        }

        [HttpPost]
        public void OfferFriendship(int id)
        {
//TODO:
            //var u = Membership.GetUser();
            //var user = UserService.GetEntity(u.UserName);
            //FriendService.OfferFriendship(user.Id, id);
        }

        [HttpPost]
        public ActionResult FriendSearch(string name)
        {
            //TODO: I Enumerable -> bad
            var users =
                    UserService.GetAll()
                        .Where(u => u.Email.Contains(name) || u.Login.Contains(name) || u.LastName.Contains(name))
                ;
            if (!users.Any())
                return HttpNotFound();

            return PartialView(users);
        }

        public void ShareFile(int friendId, int fileId)
        {
            //var u = Membership.GetUser();
            //var user = UserService.GetEntity(u.UserName);
            //FileService.(user.Id, friendId, fileId);
        }

        public ActionResult Search()
        {
            return View();
        }
    }
}