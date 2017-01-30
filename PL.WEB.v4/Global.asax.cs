using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PL.WEB.v4.Controllers;

namespace PL.WEB.v4
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //https://www.simple-talk.com/dotnet/asp-net/pragmatic-web-error-handling-asp-net-mvc/
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            if (ReferenceEquals(exception, null)) return;

            Response.Clear();
            var routeData = new RouteData();
            var httpErrorCode = (exception as HttpException)?.GetHttpCode();

            routeData.Values.Add("httpErrorCode", httpErrorCode);
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Index");
            routeData.Values.Add("exception", exception);

            IController controller = new ErrorController();
            controller.Execute(new RequestContext(new HttpContextWrapper(Context), routeData));

            Response.End();
        }
    }
}
