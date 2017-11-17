using MagneticNote.Common;
using MoeMoeD.Filter;
using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace MoeMoeD.Controllers
{
    public class HomeController : Controller
    {
        [Dependency]
        public IUserBLL UserBLL { get; set; }
        [Dependency]
        public IFileBLL FileBLL { get; set; }
        [Dependency]
        public IFileContentBLL FileContentBLL { get; set; }
        [Dependency]
        public IFolderBLL FolderBLL { get; set; }

        public ActionResult Index()
        {
            if (Request.Url.LocalPath != "/" && Request.Url.LocalPath != "/index.html")
            {
                return Redirect("/");
            }
            User user = Session["User"] as User;

            if (user == null)
            {
                return Redirect(Url.Content("~/index.html"));
            }
            else
            {
                return View();
            }
        }

        [FilterIsLogin]
        public ActionResult Get(String FolderId)
        {
            User user = Session["User"] as User;
            int folderId = 1;
            if (FolderId != null) folderId = Convert.ToInt32(FolderId);
            if (user == null)
            {
                ResponseHelper.WriteNull(Response);
            }
            else
            {
                if (folderId == 1)
                {
                    var fileList = FileBLL.GetRootByUserId(user.Id);
                    var folderList = FolderBLL.GetRootByUserId(user.Id);
                    var dataList = new List<DataList>();
                    foreach (var v in fileList)
                    {
                        dataList.Add(new DataList { Id = v.Id, Type = v.Type, Size = v.Size, UpdateTime = v.UpdateTime, Name = v.Name });
                    }
                    foreach (var v in folderList)
                    {
                        dataList.Add(new DataList { Id = v.Id, Type = "Folder", Size = "-", UpdateTime = v.UpdateTime, Name = v.Name });
                    }
                    ResponseHelper.WriteObject(Response, new { DataList = dataList });
                }
                else
                {
                    var fileList = FileBLL.GetByFolderId(folderId);
                    var folderList = FolderBLL.GetByFolderId(folderId);
                    var dataList = new List<DataList>();
                    foreach (var v in fileList)
                    {
                        dataList.Add(new DataList { Id = v.Id, Type = v.Type, Size = v.Size, UpdateTime = v.UpdateTime, Name = v.Name });
                    }
                    foreach (var v in folderList)
                    {
                        dataList.Add(new DataList { Id = v.Id, Type = "Folder", Size = "-", UpdateTime = v.UpdateTime, Name = v.Name });
                    }
                    ResponseHelper.WriteObject(Response, new { DataList = dataList });
                }
            }

            return null;
        }

        [FilterIsLogin]
        public ActionResult Upload(String FolderId)
        {
            User user = Session["User"] as User;
            if (user == null)
            {
                return new RedirectResult(Url.Action("Index", "Error"));
            }

            if (Request.Files.Count > 0)
            {
                Console.Write(Request.Files[0].GetType());
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i] as HttpPostedFileWrapper;
                    var sha1 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                    var md5byte = sha1.ComputeHash(file.InputStream);
                    String MD5 = Convert.ToBase64String(md5byte);
                    MD5 = Hash_MD5_16(MD5);

                    int folderId = Convert.ToInt32(FolderId);
                    int userId = user.Id;
                    if (folderId > 0)
                    {
                        userId = 1;
                    }
                    else
                    {
                        folderId = 1;
                    }

                    var fileContent = FileContentBLL.GetByMD5(MD5);
                    if (fileContent != null)
                    {
                        var File = new File() { FileContentId = fileContent.Id, FolderId = folderId, UserId = userId, Name = file.FileName, Size = file.ContentLength.ToString(), Type = file.ContentType, UpdateTime = DateTime.Now.ToShortDateString() };
                        File value = FileBLL.Add(File);
                        fileContent.Data.Close();
                        ResponseHelper.WriteObject(Response, new { Result = true, File = value });
                    }
                    else
                    {
                        file.SaveAs(AppDomain.CurrentDomain.BaseDirectory + "/file/" + MD5);

                        var content = new FileContent() { Data = file.InputStream, MD5 = MD5 };

                        content = FileContentBLL.Add(content);

                        var File = new File() { FileContentId = content.Id, FolderId = folderId, UserId = userId, Name = file.FileName, Size = file.ContentLength.ToString(), Type = file.ContentType, UpdateTime = DateTime.Now.ToShortDateString() };
                        var value = FileBLL.Add(File);

                        content.Data.Close();

                        ResponseHelper.WriteObject(Response, new { Result = true, File = value });
                    }
                }
                ResponseHelper.WriteFalse(Response);
            }

            return null;
        }

        public ActionResult Login(String Email, String Name, String Password)
        {
            string email = Email;
            string name = Name;
            string passWord = Password;

            if (!String.IsNullOrEmpty(email))
            {
                var user = UserBLL.GetByEmail(email);
                if (user == null || user.Password != passWord)
                {
                    ResponseHelper.WriteFalse(Response);
                    return null;
                }
                Session["User"] = user;
                ResponseHelper.WriteObject(Response, user);
            }
            else if (!String.IsNullOrEmpty(name))
            {
                var user = UserBLL.GetByName(name);
                if (user == null || user.Password != passWord)
                {
                    ResponseHelper.WriteFalse(Response);
                    return null;
                }
                Session["User"] = user;
                ResponseHelper.WriteTrue(Response);
            }
            ResponseHelper.WriteFalse(Response);
            return null;
        }

        [FilterIsLogin]
        public ActionResult Delete(List<IdList> IdList)
        {
            if (IdList != null && IdList.Count > 0)
            {
                foreach (IdList value in IdList)
                {
                    if (value.Type.Equals("Folder"))
                    {
                        if (FolderBLL.DeleteById(value.Id) == false)
                        {
                            ResponseHelper.WriteFalse(Response);
                            return null;
                        }
                    }
                    else
                    {
                        if (FileBLL.DeleteById(value.Id) == false)
                        {
                            ResponseHelper.WriteFalse(Response);
                            return null;
                        }
                    }
                }
                ResponseHelper.WriteTrue(Response);
            }

            return null;
        }

        public class IdList
        {
            public int Id { get; set; }
            public String Type { get; set; }
        }

        public class DataList
        {
            public int Id { get; set; }
            public String Type { get; set; }
            public String Size { get; set; }
            public String UpdateTime { get; set; }
            public String Name { get; set; }
        }

        public static string Hash_MD5_16(string word, bool toUpper = true)
        {
            try
            {
                string sHash = Hash_MD5_32(word).Substring(8, 16);
                return toUpper ? sHash : sHash.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static string Hash_MD5_32(string word, bool toUpper = true)
        {
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider MD5CSP
                 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(word);
                byte[] bytHash = MD5CSP.ComputeHash(bytValue);
                MD5CSP.Clear();
                //根据计算得到的Hash码翻译为MD5码
                string sHash = "", sTemp = "";
                for (int counter = 0; counter < bytHash.Count(); counter++)
                {
                    long i = bytHash[counter] / 16;
                    if (i > 9)
                    {
                        sTemp = ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp = ((char)(i + 0x30)).ToString();
                    }
                    i = bytHash[counter] % 16;
                    if (i > 9)
                    {
                        sTemp += ((char)(i - 10 + 0x41)).ToString();
                    }
                    else
                    {
                        sTemp += ((char)(i + 0x30)).ToString();
                    }
                    sHash += sTemp;
                }
                //根据大小写规则决定返回的字符串
                return toUpper ? sHash : sHash.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}