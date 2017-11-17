using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Filter
{
    public class FilterIsLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.HttpContext.Response.Redirect("~/index.html", false);
            }
        }
    }
}