using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PL.WEB.v4.Infrastructure;
using RFoundation.BLL.Interfaces.Entities;
using RFoundation.BLL.Interfaces.Services;
using RFoundation.PL.WEB.Models;
using WebGrease.Css.Extensions;

namespace PL.WEB.v4.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IFileService FileService => (IFileService) DependencyResolver.Current.GetService(typeof(IFileService));
        public IUserService UserService => (IUserService) DependencyResolver.Current.GetService(typeof(IUserService));

        public IExtensionService ExtensionService
            => (IExtensionService) DependencyResolver.Current.GetService(typeof(IExtensionService));

        private BllUser CurrentUser => UserService?.Get(Membership.GetUser()?.Email);

        public ActionResult Index()
        {
            var name = CurrentUser?.Login ?? "anonymous";
            Session["Login"] = name;
            ViewBag.User = name;
            var userFiles = CurrentUser?.Files;
            if (userFiles == null) return View();

            var extensions = ExtensionService.GetAll().ToList();
            var viewFiles = new List<FileViewModel>();
            foreach (var userFile in userFiles)
            {
                userFile.Extension = extensions.FirstOrDefault(e => e.Id == userFile.ExtensionId);
                viewFiles.Add(userFile.ToMvcFile());
            }

            var recivedFilesIds = CurrentUser.ReceivedFiles.Select(ef => ef.FileId).ToList();

            foreach (var id in recivedFilesIds)
            {
                var file = FileService.Get(id).ToMvcFile();
                file.Received = true;
                viewFiles.Add(file);
            }

            if (Request.IsAjaxRequest())
                return PartialView(viewFiles);

            return View(viewFiles);
        }

        public ActionResult Shared()
        {
            var name = CurrentUser?.Login ?? "anonymous";
            ViewBag.User = name;
            var userFiles = CurrentUser?.Files;
            if (userFiles == null) return View();

            var extensions = ExtensionService.GetAll().ToList();
            var viewFiles = new List<FileViewModel>();

            var sharedFilesIds = CurrentUser.SharedFiles.Select(ef => ef.FileId).ToList();

            foreach (var id in sharedFilesIds)
            {
                var file = userFiles.First(i => i.Id == id).ToMvcFile();

                viewFiles.Add(file);
            }

            if (Request.IsAjaxRequest())
                return PartialView(viewFiles);
            return View(viewFiles);
        }

        public ActionResult Recieved()
        {
            var name = CurrentUser?.Login ?? "anonymous";
            ViewBag.User = name;
            var userFiles = CurrentUser?.Files;
            if (userFiles == null) return View();

            var extensions = ExtensionService.GetAll().ToList();
            var viewFiles = new List<FileViewModel>();

            var recivedFilesIds = CurrentUser.ReceivedFiles.Select(ef => ef.FileId).ToList();

            foreach (var id in recivedFilesIds)
            {
                var file = FileService.Get(id).ToMvcFile();
                file.Received = true;
                viewFiles.Add(file);
            }

            if (Request.IsAjaxRequest())
                return PartialView(viewFiles);

            return View(viewFiles);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.User = CurrentUser.Login;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.User = CurrentUser.Login;
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
            string file_name = file.Name + "." +
                               extensions?.FirstOrDefault(e => e.Id == file.ExtensionId)?.ExtensionName;
            return File(mas, file_type, file_name);
        }

        public ActionResult Upload2(IEnumerable<HttpPostedFileBase> upload)
        {
            if (upload != null)
            {
                foreach (var up in upload)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(up.FileName);
                    // сохраняем файл в папку Files в проекте
                    BinaryReader reader = new BinaryReader(up.InputStream);
                    byte[] data = reader.ReadBytes(up.ContentLength);

                    var s = up.FileName.IndexOf(".", StringComparison.Ordinal);


                    string name = up.FileName.Substring(0, s);
                    string extension = up.FileName.Substring(s + 1);
                    var exts = ExtensionService?.GetAll()?.FirstOrDefault(e => e.ExtensionName == extension)?.Id;
                    FileService.Create(new BllFile()
                    {
                        Name = name,
                        IsProfileImage = false,
                        Banned = false,
                        UploadDate = DateTime.Now,
                        ExtensionId = exts ?? 1,
                        Data = data,
                        Size = up.ContentLength,
                        UserId = CurrentUser.Id
                    });
                }
            }
            return PartialView("Index");
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
                var exts = ExtensionService?.GetAll()?.FirstOrDefault(e => e.ExtensionName == extension)?.Id;
                FileService.Create(new BllFile()
                {
                    Name = name,
                    IsProfileImage = false,
                    Banned = false,
                    UploadDate = DateTime.Now,
                    ExtensionId = exts ?? 1,
                    Data = data,
                    Size = upload.ContentLength,
                    UserId = CurrentUser.Id
                });
            }
            return PartialView("Index");
        }

        public ActionResult DeleteFile(int id)
        {
            FileService.Delete(id);
            return Redirect("/Home/Index");
        }
        [HttpGet]
        public ActionResult Upload3()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload4(string s)
        {
            var filex = Request.Files;
            var x = filex.AllKeys;
            var v = filex[x[0]];

            return View();
        }

        [HttpPost]
        public ActionResult Upload()
        {
            foreach (string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (upload != null)
                {
                    // получаем имя файла
                    string fileName = System.IO.Path.GetFileName(upload.FileName);
                    // сохраняем файл в папку Files в проекте
                    //  upload.SaveAs(Server.MapPath("~/Files/" + fileName));
                    BinaryReader reader = new BinaryReader(upload.InputStream);
                    byte[] data = reader.ReadBytes(upload.ContentLength);

                    var s = upload.FileName.IndexOf(".", StringComparison.Ordinal);


                    string name = upload.FileName.Substring(0, s);
                    string extension = upload.FileName.Substring(s + 1);
                    var exts = ExtensionService?.GetAll()?.FirstOrDefault(e => e.ExtensionName == extension)?.Id;
                    FileService.Create(new BllFile()
                    {
                        Name = name,
                        IsProfileImage = false,
                        Banned = false,
                        UploadDate = DateTime.Now,
                        ExtensionId = exts ?? 1,
                        Data = data,
                        Size = upload.ContentLength,
                        UserId = CurrentUser.Id
                    });
                    
                }
            }
            return RedirectToAction("Index");
        }
    }
}