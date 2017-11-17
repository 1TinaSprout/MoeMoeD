using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MagneticNote.Common;
using Unity.Attributes;
using MoeMoeD.Filter;

namespace MoeMoeD.Controllers
{
    public class FolderController : Controller
    {
        [Dependency]
        protected IFolderBLL FolderBLL { get; set; }

        [FilterIsLogin]
        public ActionResult Get()
        {
            if (Request["Id"] != null && Request["Id"] != "")
            {
                Folder folder = FolderBLL.GetById(Convert.ToInt32(Request["Id"]));
                ResponseHelper.WriteObject(Response, "Folder", folder);
            }
            if (Request["UserId"] != null && Request["UserId"] != "")
            {
                IList<Folder> folder = FolderBLL.GetRootByUserId(Convert.ToInt32(Request["UserId"]));
                ResponseHelper.WriteList(Response, "FolderList", folder);
            }
            if (Request["FolderId"] != null && Request["FolderId"] != "")
            {
                IList<Folder> folder = FolderBLL.GetByUserId(Convert.ToInt32(Request["FolderId"]));
                ResponseHelper.WriteList(Response, "FolderList", folder);
            }
            ResponseHelper.WriteNull(Response);
            return null;
        }

        [HttpPost]
        [FilterIsLogin]
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
        [FilterIsLogin]
        public ActionResult Delete(int Id)
        {
            if (Id != 0)
            {
                if (FolderBLL.DeleteById(Id))
                {
                    ResponseHelper.WriteTrue(Response);
                }
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }

        [HttpPost]
        [FilterIsLogin]
        public ActionResult Add(String Name, String FolderId)
        {
            User user = Session["User"] as User;
            if(user == null)
            {
                ResponseHelper.WriteNull(Response);
                return null;
            }
            if (!String.IsNullOrEmpty(Name))
            {
                if (FolderId == null && FolderBLL.GetByNameAndUserId(Name, user.Id) == null)
                {
                    var folder = new Folder() { Name = Name, UserId = user.Id, ParentId = 1, UpdateTime = DateTime.Now.ToShortDateString() };
                    folder = FolderBLL.Add(folder);
                    if (folder == null)
                    {
                        ResponseHelper.WriteFalse(Response);
                    }
                    else
                    {
                        var val = new { Id = folder.Id, Type = "Folder", Size = "-", UpdateTime = folder.UpdateTime, Name = folder.Name};
                        ResponseHelper.WriteObject(Response, new { Result = true, Folder = val });
                    }
                }
                else if(FolderId != null){
                    var folderId = Convert.ToInt32(FolderId);
                    if (FolderBLL.GetByNameAndFolderId(Name, folderId) == null)
                    {
                        var folder = new Folder() { Name = Name, UserId = 1, ParentId = folderId, UpdateTime = DateTime.Now.ToShortDateString() };
                        folder = FolderBLL.Add(folder);
                        if (folder == null)
                        {
                            ResponseHelper.WriteFalse(Response);
                        }
                        else
                        {
                            var val = new { Id = folder.Id, Type = "Folder", Size = "-", UpdateTime = folder.UpdateTime, Name = folder.Name };
                            ResponseHelper.WriteObject(Response, new { Result = true, Folder = val });
                        }
                    }
                }
                else
                {
                    ResponseHelper.WriteNull(Response);
                }
            }
            return null;
        }

    }
}