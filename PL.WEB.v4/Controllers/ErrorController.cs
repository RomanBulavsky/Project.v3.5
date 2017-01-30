using System;
using System.Web.Mvc;

namespace PL.WEB.v4.Controllers
{
    public class ErrorController : Controller
    {
      
        public ActionResult Index(Exception exception, int httpErrorCode = 0)
        {
            if (httpErrorCode == 404)
                return View("NotFound");
            return View("Error");
        }
    }
}