using MagneticNote.Common;
using MoeMoeD.Filter;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace MoeMoeD.Controllers
{
    public class ChatroomController : Controller
    {
        public static Dictionary<String, User> UserSet { get; set; }

        public ChatroomController()
        {
            if(UserSet == null)
            {
                lock (this)
                {
                    if(UserSet == null)
                    {
                        UserSet = new Dictionary<string, Model.ViewData.User>();
                    }
                }
            }
        }
        [FilterIsLogin]
        // GET: Chatroom
        public ActionResult Index()
        {
            return View();
        }

        [FilterIsLogin]
        public ActionResult Get()
        {
            if (UserSet.Count > 0)
            {
                ResponseHelper.WriteList(Response, UserSet.Values.ToList());
            }
            else
            {
                ResponseHelper.WriteNull(Response);
            }

            return null;
        }
    }
}