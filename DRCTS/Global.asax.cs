using DRCTS.App_Start;
using IdentitySample.Models;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace IdentitySample
{
    // Note: For instructions on enabling IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=301868
    public class MvcApplication : System.Web.HttpApplication
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            // Register Web API routing support before anything else
            GlobalConfiguration.Configure(WebApiConfig.Register);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            //log the error!
            logger.Error(ex);
            Session["uError"] = User.Identity.Name.ToString();
            Session["Error"] = ex.InnerException;
        }
    }
}
