using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            User user = Session["User"] as User;

            if (user != null)
            {
                return View("Home");
            }

            Server.TransferRequest("./index.html");
            Response.End();
            return Json(new { });
        }
    }
}