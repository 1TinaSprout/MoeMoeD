using MagneticNote.Common;
using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Controllers
{
    public class HomeController : Controller
    {
        public IFileBLL FileBLL { get; set; }
        public IFileContentBLL FileContentBLL { get; set; }
        public ActionResult Index()
        {
            User user = Session["User"] as User;

            return View();
            //if (user == null)
            //{
            //    return Redirect(Url.Content("~/index.html"));
            //}
            //else
            //{
            //}
        }

        public ActionResult Get()
        {
            ResponseHelper.WriteNull(Response);

            return null;
        }

        public ActionResult Upload()
        {
            User user = Session["User"] as User;
            if(user == null)
            {
                return new RedirectResult(Url.Action("Index", "Error"));
            }

            if (Request.Files.Count > 0)
            {
                Console.Write(Request.Files[0].GetType());
                foreach(HttpPostedFileWrapper file in Request.Files)
                {
                    var md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    var MD5 = md5.ComputeHash(file.InputStream);

                    if (!FileBLL.IsContains(MD5))
                    {
                        if (FileContentBLL.Add(new FileContent() { })) ;
                    }
                }
                ResponseHelper.WriteTrue(Response);
            }
            else
            {
                ResponseHelper.WriteFalse(Response);
            }

            return null;
        }
    }
}