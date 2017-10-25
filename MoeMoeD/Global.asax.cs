using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MoeMoeD
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            UnityConfig.RegisterComponents();

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_BeginRequest()
        {
            if (Request.Url.Segments[0] == "/" || Request.Url.Segments[0] + Request.Url.Segments[1] != "/Home/")
            {
                return;
            }

            User user = Session["User"] as User;

            if (user == null)
            {
                Response.ContentType = "text/html;charset=UTF-8";
                Response.Write("404");
                Response.End();
            }
        }
    }
}
