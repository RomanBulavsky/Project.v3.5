using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Services;

namespace RFoundation.PL.WEB.Controllers
{
    public class HomeController : Controller
    {
        //Все в BLL
        public IFileService FileService => (IFileService)DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
        string Name = Membership.GetUser()?.UserName ?? "Anon";

        public ActionResult Index()
        {
            //IEnumerable<FileEntity> files = FileService.GetAllEntitiesByEmail(Name);
            //if (files == null) return View();
            //List<FileViewModel> viewFiles = new List<FileViewModel>();
            //foreach (var fileEntity in files)
            //{
            //    //viewFiles.Add(fileEntity.ToMvcFile());
            //}
            //ViewBag.Files = viewFiles;
            ViewBag.User = Name;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.User = Name;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.User = Name;
            return View();
        }




        

        public ActionResult DeleteFile(int id)
        {
            FileService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}