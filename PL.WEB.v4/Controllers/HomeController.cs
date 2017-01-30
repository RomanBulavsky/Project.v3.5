using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using WebGrease.Css.Extensions;

namespace PL.WEB.v4.Controllers
{
    public class HomeController : Controller
    {
        public IFileService FileService => (IFileService) DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        public IExtensionService ExtensionService => (IExtensionService)DependencyResolver.Current.GetService(typeof(IExtensionService));
        string Name = Membership.GetUser()?.UserName ?? "Anon";
        private int? Id => UserService?.GetAll()?.FirstOrDefault(u => u.Login == Name)?.Id;

        public ActionResult Index()
        {
            BllUser user = null;
            if (!Name.Equals("Anon"))
             user = UserService.Get(Membership.GetUser().Email);
            
            IEnumerable<BllFile> files = user?.Files;
            if (files == null) return View();
            List<BllFile> viewFiles = new List<BllFile>();
            var extensions = ExtensionService.GetAll().ToList();
            foreach (var fileEntity in files)
            {
                fileEntity.Extension = extensions.FirstOrDefault(e => e.Id == fileEntity.ExtensionId);
                viewFiles.Add(fileEntity);
            }
            //ViewBag.Files = viewFiles;
            ViewBag.User = Name;
            return View(viewFiles.ToList());
        }

        public ActionResult Shared()
        {
            BllUser user = null;
            if (!Name.Equals("Anon"))
                user = UserService.Get(Membership.GetUser().Email);

            IEnumerable<BllSharedFile> sfiles = user?.SharedFiles;
            ICollection<BllFile> files = user?.Files;

            if (files == null) return View();
            List<BllFile> viewFiles = new List<BllFile>();
            var extensions = ExtensionService.GetAll().ToList();

            foreach (var fileEntity in files)
            {
                fileEntity.Extension = extensions.FirstOrDefault(e => e.Id == fileEntity.ExtensionId);
                viewFiles.Add(fileEntity);
            }
            //ViewBag.Files = viewFiles;
            ViewBag.User = Name;
            return View(viewFiles.ToList());
        }

        public ActionResult Recieved()
        {
            BllUser user = null;
            if (!Name.Equals("Anon"))
                user = UserService.Get(Membership.GetUser().Email);

            IEnumerable<BllSharedFile> rfiles = user?.ReceivedFiles;
            ICollection<BllFile> files = user?.Files;

            if (files == null) return View();
            List<BllFile> viewFiles = new List<BllFile>();
            var extensions = ExtensionService.GetAll().ToList();

            foreach (var fileEntity in files)
            {
                fileEntity.Extension = extensions.FirstOrDefault(e => e.Id == fileEntity.ExtensionId);
                viewFiles.Add(fileEntity);
            }
            //ViewBag.Files = viewFiles;
            ViewBag.User = Name;
            return View(viewFiles.ToList());
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

        public ActionResult Download(object fileEntity)
        {
            //naryWriter bw = new BinaryWriter();
            var fileEntity2 = (BllFile) fileEntity;

            BinaryWriter writer =
                new BinaryWriter(new FileStream($"{fileEntity2.Name}.{fileEntity2.Extension}", FileMode.Create));
            writer.Write(((BllFile) fileEntity).Data);

            return View("Index");
        }

        public FileResult GetFile(int id)
        {
            var file = FileService.Get(id);
            byte[] mas = file.Data;
            string file_type = "text/plain";
            var extensions = ExtensionService.GetAll().ToList();
            string file_name = file.Name + "." + extensions?.FirstOrDefault(e=>e.Id == file.ExtensionId)?.ExtensionName;
            return File(mas, file_type, file_name);
        }

        public ActionResult Upload(HttpPostedFileBase upload)
        {
            if (upload != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(upload.FileName);
                // сохраняем файл в папку Files в проекте
                BinaryReader reader = new BinaryReader(upload.InputStream);
                byte[] data = reader.ReadBytes(upload.ContentLength);

                var s = upload.FileName.IndexOf(".", StringComparison.Ordinal);


                string name = upload.FileName.Substring(0, s);
                string extension = upload.FileName.Substring(s + 1);
                FileService.Create(new BllFile()
                {
                    Name = name,
                    IsProfileImage = false,

                    Banned = false,
                    UploadDate = DateTime.Now,
                    
                    ExtensionId = 1,
                    Data = data,
                    Size = upload.ContentLength,
                    UserId = (int)Id//(int)Session["UserId"]//TODO:!~!~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                });
                //upload.SaveAs(Server.MapPath("~/Files/" + fileName));
            }
            return Redirect("/Home/Index");
        }

        public ActionResult DeleteFile(int id)
        {
            FileService.Delete(id);
            return Redirect("/Home/Index");
        }
    }
}