using Microsoft.Practices.Unity;
using MoeMoeD.BLL;
using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Controllers
{
    public class UserController : Controller
    {
        [Dependency]
        public UserBLL userBLL { get; set; }

        public JsonResult Login(String phone, String email, String userName, String password)
        {
            
            User user = null;
            if(!String.IsNullOrEmpty(phone))
            {
                user = userBLL.GetUserByPhone(phone);
            }
            else if (!String.IsNullOrEmpty(email))
            {
                user = userBLL.GetUserByPhone(email);
            }
            else if (!String.IsNullOrEmpty(userName))
            {
                user = userBLL.GetUserByName(userName);
            }

            if(user != null && user.Password.Equals(password))
            {
                Session.Add("User", user);
                return Json(new { Result = 1 });
            }
            else
            {
                return Json(new { Result = 2 });
            }
        }
    }
}