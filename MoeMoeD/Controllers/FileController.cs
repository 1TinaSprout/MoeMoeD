
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
    public class FileController : Controller
    {
        [Dependency]
        public IFileBLL FileBLL { get; set; }
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get()
        {
            if (Request["Id"] != null && Request["Id"] != "")
            {
                int id = Convert.ToInt32(Request["Id"]);
                File file = FileBLL.GetById(id);
                ResponseHelper.WriteObject(Response, "File", file);
            }
            if (Request["UserId"] != null && Request["UserId"] != "")
            {
                int userId = Convert.ToInt32(Request["UserId"]);
                IList<File> listFile = FileBLL.GetRootByUserId(userId);
                ResponseHelper.WriteList(Response, "FileList", listFile);
            }
            if (Request["FolderId"] != null && Request["FolderId"] != "")
            {
                int folderId = Convert.ToInt32(Request["FolderId"]);
                IList<File> filelst = FileBLL.GetByFolderId(folderId);
                ResponseHelper.WriteList(Response, "FileList", filelst);
            }
            ResponseHelper.WriteNull(Response);
            return null;
        }

        public ActionResult UpdateName()
        {
            if (Request["Id"] != null && Request["Name"] != null
                && Request["Id"] != "" && Request["Name"] != "")
            {
                int id = Convert.ToInt32(Request["Id"]);
                string name = Request["Name"];
                if (FileBLL.UpdateNameById(id, name))
                {
                    ResponseHelper.WriteTrue(Response);
                }
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }

        public ActionResult Delete()
        {
            if (Request["Id"] != null && Request["id"] != "")
            {
                int id = Convert.ToInt32(Request["Id"]);
                if (FileBLL.DeleteById(id))
                {
                    ResponseHelper.WriteTrue(Response);
                }
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }

        public ActionResult GetContent()
        {
            return null;
        }


    }
}