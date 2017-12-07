using MoeMoeD.Common;
using MoeMoeD.Filter;
using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public IUserBLL UserBLL { get; set; }

        [FilterIsLogin]
        public ActionResult Get()
        {
            string email = Request["Email"];
            string name = Request["Name"];

            if (name != null)
            {
                ResponseHelper.WriteObject(Response, UserBLL.GetByName(name));
            }
            else if (email != null)
            {
                ResponseHelper.WriteObject(Response, UserBLL.GetByEmail(email));
            }
            else if (Session["User"] != null)
            {
                User user = Session["User"] as User;
                ResponseHelper.WriteObject(Response, "User", user);
            }
            else
            {
                ResponseHelper.WriteNull(Response);
            }
            ResponseHelper.WriteNull(Response);
            return null;
        }

        [HttpPost]
        [FilterIsLogin]
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

        [FilterIsLogin]
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