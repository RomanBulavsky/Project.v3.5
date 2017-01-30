using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;

namespace PL.WEB.v4.Controllers
{
    [Authorize]
    public class FriendController : Controller
    {
        public IFileService FileService => (IFileService) DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));
        string Name = Membership.GetUser()?.UserName ?? "Anon";
        private int Id => UserService.GetAll().FirstOrDefault(u => u.Login == Name).Id;
        private BllUser User => UserService.GetAll().FirstOrDefault(u => u.Login == Name);

        public IFriendService FriendService
            => (IFriendService) DependencyResolver.Current.GetService(typeof(IFriendService));

        public IFriendInvitationService FriendInviteService
            => (IFriendInvitationService) DependencyResolver.Current.GetService(typeof(IFriendInvitationService));

        private BllUser CurrentUser => UserService?.Get(Membership.GetUser()?.Email);

        public ActionResult FriendList()
        {
            var friendIds = CurrentUser.Friends.Select(f => f.UserId);
            var friends = new List<BllUser>();

            foreach (var id in friendIds)
            {
                var user = UserService.Get(id);
                friends.Add(user);
            }
            if (Request.IsAjaxRequest())
                return PartialView(friends);

            return View(friends);
        }

        public ActionResult FriendOfferList()
        {
            var u = Membership.GetUser();

            return View(User.FriendRequests);
        }

        //TODO:POST
        public ActionResult AddToFriends(int friendId)
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

            return RedirectToAction("FriendList", "Friend");
        }

        //TODO:POST
        public ActionResult DeleteFromFriends(int friendId)
        {
            var friends = CurrentUser.Friends.ToList();
            var friend = friends.FirstOrDefault(f => f.UserId == friendId);

            if (friend != null)
            {
                FriendService.Delete(friend.Id);
            }

            return
                RedirectToAction("FriendList", "Friend");
        }

        [HttpGet]
        public ActionResult OfferFriendship(int id)
        {
            //TODO:Checks!!!!
            var userId = CurrentUser.Id;
            var friendRequest = new BllFriendRequest()
            {
                FromUserId = userId,
                ToUserId = id
            };
            FriendInviteService.Create(friendRequest);
            return RedirectToAction("Offers", "Friend");
        }


        [HttpPost]
        public ActionResult FriendSearch(string name)
        {
            //TODO: I Enumerable -> bad
            var users =
                UserService.GetAll()
                    .Where(u => u.Email.Contains(name) || u.Login.Contains(name) || u.LastName.Contains(name)).ToList();
            var friendIds = CurrentUser.Friends.Select(f => f.UserId).ToList();
            var resultUsers = new List<BllUser>();

            var us = users.Select(u => u.Id);
            var resultIds = us.Except(friendIds);

            foreach (var resultId in resultIds)
            {
                resultUsers.Add(UserService.Get(resultId));
            }
            if (!users.Any())
                return HttpNotFound();

            return PartialView(resultUsers);
        }


        public ActionResult Search()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        public ActionResult Invites()
        {
            var u = Membership.GetUser();
            var user = UserService.Get(u.Email);
            var offers = FriendInviteService.GetAll().Where(fo => fo.ToUserId == user.Id).ToList();
            if (Request.IsAjaxRequest())
                return PartialView(offers);
            return View(offers);
        }

        public ActionResult Offers()
        {
            var u = Membership.GetUser();
            var user = UserService.Get(u.Email);
            var requests = FriendInviteService.GetAll().Where(fo => fo.FromUserId == user.Id).ToList();
            if (Request.IsAjaxRequest())
                return PartialView(requests);
            return View(requests);
        }
    }
}