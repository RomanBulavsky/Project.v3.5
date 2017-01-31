using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.PL.WEB.Models;

namespace PL.WEB.v4.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        private BllUser CurrentUser => UserService?.Get(Membership.GetUser()?.Email);

        public ActionResult Landing()
        {
            return View();
        }

        public ActionResult Login()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Email, model.Password))
                    //При логине метод Membership.ValidateUser проверяет, имеется ли в базе данных пользователь с введенными логином и паролем в системе.
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    Session["UserId"] = UserService.GetAll()?.FirstOrDefault(u => u.Email == model.Email)?.Id;
                    Session["Auth"] = 0;
                    ViewBag.User = model.Email;
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Wrong password");
                }
            }
            if (Request.IsAjaxRequest())
                return PartialView(model);
            return View(model);
        }

        public ActionResult LogOff()
        {
            Session["Login"] =  null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
            if (Request.IsAjaxRequest())
                return PartialView();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;

                Membership.CreateUser(model.Login, model.Password, model.Email, null, null, false, false,
                    out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    Session["UserId"] = UserService.GetAll()?.FirstOrDefault(u => u.Email == model.Email)?.Id;
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Registration Error");
                }
            }
            if (Request.IsAjaxRequest())
                return PartialView(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProfileCustomization(UserViewModel viewUser)
        {
            var user = UserService.Get(CurrentUser.Id);
            user.Birthdate = viewUser.Birthdate;
            user.FirstName = viewUser.FirstName;
            user.LastName = viewUser.LastName;
            user.LastUpdateDate = DateTime.Now;
            UserService.Update(user);
            user = UserService.Get(CurrentUser.Id);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ProfileCustomization()
        {
            var viewProfile = new UserViewModel()
            {
                Birthdate = CurrentUser.Birthdate,
                LastName = CurrentUser.LastName,
                FirstName = CurrentUser.FirstName
            };
            if (Request.IsAjaxRequest())
                return PartialView(viewProfile);
            return View(viewProfile);
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult CheckLogin(string login)
        {
            var user = UserService.GetAll()?.FirstOrDefault(u => u.Login == login);
            return Json(user == null, JsonRequestBehavior.AllowGet);
            //if (user != null) return Json("Login is already exist ~~ Json", JsonRequestBehavior.AllowGet);
            //return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult CheckEmail(string email)
           {
            var user = UserService.GetAll()?.FirstOrDefault(u => u.Email == email);
            return Json(user == null, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult CheckEmail2(string email)
        {
            var user = UserService.GetAll()?.FirstOrDefault(u => u.Email == email);
            return Json(user != null, JsonRequestBehavior.AllowGet);
        }
    }
}