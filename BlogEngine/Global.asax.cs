using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DAL.Init;

namespace BlogEngine
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Resetting Engines
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            //ObjectFactory Init
            GeneralManager.Initialize();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }

        protected void Application_End()
        {
            GeneralManager.Dispose();
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            GeneralManager.EndRequest(sender, e);
        }

        /// <summary>
        ///     The session_ end.
        /// </summary>
        /// <param name="sender">
        /// </param>
        /// <param name="e">
        /// </param>
        private void Session_End(object sender, EventArgs e)
        {
            if (HttpContext.Current == null) return;

            // Remove session
            //HttpContext.Current.Session.Remove("ProfileCache");
        }

       
    }
}