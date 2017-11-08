using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MagneticNote.Common;

namespace MoeMoeD.Controllers
{
    public class FolderController : Controller
    {
        private IFolderBLL FolderBLL { get; set; }
        // GET: Folder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Get()
        {
            if (Request["Id"] != null && Request["Id"] != "")
            {
                Folder folder = FolderBLL.GetById(Convert.ToInt32(Request["Id"]));
                ResponseHelper.WriteObject(Response, folder);
            }
            if (Request["UserId"] != null && Request["UserId"] != "")
            {
                IList<Folder> folder = FolderBLL.GetRootByUserId(Convert.ToInt32(Request["UserId"]));
                ResponseHelper.WriteObject(Response, folder);
            }
            if (Request["FolderId"] != null && Request["FolderId"] != "")
            {
                IList<Folder> folder = FolderBLL.GetByUserId(Convert.ToInt32(Request["FolderId"]));
                ResponseHelper.WriteObject(Response, folder);
            }
            ResponseHelper.WriteNull(Response);
            return null;
        }
        [HttpPost]
        public ActionResult UpdateName()
        {
            if (Request["Name"] != null && Request["Name"] != "" &&
                Request["Id"] != null && Request["Id"] != null)
            {
                if (FolderBLL.UpdateNameById(Convert.ToInt32(Request["Id"]), Request["Name"]))
                {
                    ResponseHelper.WriteTrue(Response);
                }
                
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }
        [HttpPost]
        public ActionResult Delete()
        {
            if (Request["Id"] != null && Request["Id"] != "")
            {
                if (FolderBLL.DeleteById(Convert.ToInt32(Request["Id"])))
                {
                    ResponseHelper.WriteTrue(Response);
                }
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }        [HttpPost]        public ActionResult Add()
        {
            return null;
        }
    }
}