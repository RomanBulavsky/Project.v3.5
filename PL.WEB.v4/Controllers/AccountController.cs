﻿using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.PL.WEB.Models;

namespace PL.WEB.v4.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        public ActionResult Landing()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
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
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
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

            return View(model);
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