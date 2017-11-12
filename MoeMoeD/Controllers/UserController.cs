using MagneticNote.Common;
using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace MoeMoeD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [Dependency]
        public IUserBLL UserBLL { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            string email = Request["Email"];
            string name = Request["Name"];

            if (email == null)
            {
                ResponseHelper.WriteObject(Response, UserBLL.GetByName(name));
            }
            else if (name != null && name != "")
            {
                ResponseHelper.WriteObject(Response, UserBLL.GetByName(email));
            }
            else
            {
                ResponseHelper.WriteNull(Response);
            }
            ResponseHelper.WriteNull(Response);
            return null;
        }

        [HttpPost]
        public ActionResult UpdateName()
        {
            string name = Request["Name"];
            if (name != null && name != "")
            {
                User user = Session["User"] as User;
                user.Name = name;
                if (UserBLL.Update(user))
                {
                    ResponseHelper.WriteTrue(Response);
                }
                else
                {
                    ResponseHelper.WriteFalse(Response);
                }

            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }

        public ActionResult UpdateEmail()
        {
            string email = Request["Email"];
            if (email != null && email != "")
            {
                if (Session["User"] != null)
                {
                    User user = Session["User"] as User;
                    user.Email = email;
                    if (UserBLL.Update(user))
                    {
                        ResponseHelper.WriteTrue(Response);
                    }
                }
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }
    }
}