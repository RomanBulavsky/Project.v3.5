using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RFoundation.PL.WEB.Controllers
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