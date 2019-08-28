using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WillAssure.Controllers;

namespace WillAssure
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

     
        protected void Session_End(Object sender, EventArgs e)
        {

            //Redirect to Login Page if Session is null & Expires                   
            new RedirectToRouteResult(new RouteValueDictionary { { "LoginPage", "LoginPageIndex" }, { "controller", "Login" } });


        }










    }
}
