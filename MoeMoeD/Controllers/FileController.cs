using Microsoft.Practices.Unity;
using MoeMoeD.BLL;
using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoeMoeD.Controllers
{
    public class FileController : Controller
    {
        [Dependency]
        public FileBLL fileBLL { get; set; }

        public JsonResult GetFile(String floderId)
        {
            User user = Session["User"] as User;

            if(user!=null)
            {
                if(floderId != null)
                {
                    int floder = 0;
                    try
                    {
                        floder = Convert.ToInt32(floderId);
                    }
                    catch (Exception){}

                    if(floder != 0)
                    {
                        List<Flie> fileList = fileBLL.GetFileByFloderId(floder);
                        return Json(fileList);
                    }
                }
                List<Flie> rootFileList = fileBLL.GetFileByUserId(user.Id);
                return Json(rootFileList);
            }
            return Json("");
        }
    }
}