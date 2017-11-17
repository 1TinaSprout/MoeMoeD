
using MagneticNote.Common;
using MoeMoeD.Filter;
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
        [Dependency]
        public IFileContentBLL FileContentBLL { get; set; }

        [FilterIsLogin]
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

        [FilterIsLogin]
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

        [FilterIsLogin]
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

        [FilterIsLogin]
        public ActionResult GetContent(String Id, String fileName)
        {
            int id = Convert.ToInt32(Id);

            File file = FileBLL.GetById(id);

            if(file != null)
            {
                var fileContent = FileContentBLL.GetById(file.FileContentId);
                Response.ContentType = file.Type;
                FileResult result = File(fileContent.Data, file.Type, fileName);
                return result;
            }

            return RedirectToAction("Index", "Error");
        }
    }
}