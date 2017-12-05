using System;
using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeMoeD.Model.ViewData;
using MoeMoeD.IBLL;
using System.IO;
using MoeMoeD.Model.Entity;

namespace MoeMoeD.BLL
{
    public class FileBLL : BaseBLL<Model.ViewData.File, Model.Entity.Flie>, IFileBLL
    {
        private IFileDAL FilDAL { get; set; }

        public FileBLL(IFileDAL fileDAL) : base(fileDAL)
        {
            this.FilDAL = fileDAL;
        }

        public override bool DeleteById(int id)
        {
            Model.Entity.Flie flie = FilDAL.GetById(id);
            return FilDAL.Delete(flie);
        }

        public IList<Model.ViewData.File> GetByUserId(int userId)
        {
            return ListDataToView(FilDAL.GetByUserId(userId));
        }

        public IList<Model.ViewData.File> GetRootByUserId(int userId)
        {
            return ListDataToView(FilDAL.GetRootByUserId(userId));
        }

        public Model.ViewData.File GetById(int id)
        {
            return DataToView(FilDAL.GetById(id));
        }

        public IList<Model.ViewData.File> GetByFolderId(int folderid)
        {
            IList<Model.Entity.Flie> flie = FilDAL.GetByFolderId(folderid);
            return ListDataToView(flie);
        }

        public bool UpdateNameById(int id, string name)
        {
            if (name == null || name == string.Empty || name == "")
            {
                return false;
            }
            else if (id == -1)
            {
                return false;
            }
            else
            {
                return FilDAL.UpdateNameById(id, name);
            }
        }

        protected IList<Model.ViewData.File> ListDataToView(IList<Model.Entity.Flie> t)
        {
            if (t == null) return null;
            IList<Model.ViewData.File> vFileLst = new List<Model.ViewData.File>();
            foreach (Model.Entity.Flie file in t)
            {
                vFileLst.Add(DataToView(file));
            }
            return vFileLst;
        }

        protected Model.ViewData.File DataToView(Model.Entity.Flie t)
        {
            if (t == null) return null;
            Model.ViewData.File vFile = new Model.ViewData.File();
            vFile.Id = t.Id;
            vFile.Name = t.Name;
            vFile.UserId = t.UserId;
            vFile.FolderId = t.FolderId;
            vFile.FileContentId = t.FileContentId;
            vFile.Size = DataSizeToView(t.Size);
            vFile.Type = t.Type;
            vFile.UpdateTime = t.UpdateTime;
            return vFile;
        }

        private string DataSizeToView(Int64 t)
        {
            
            double item = 0;
            if (t < 1024 && t >= 0)
            {
                return (t).ToString() + "B";
            }
            else if (t < 1048576 && t >= 1024)
            {
                item = t / 1024;
                return (Math.Round(item, 2)).ToString() + "K";
            }
            else if (t < 1073741824 && t > 1048576)
            {
                item = t / 1048576;
                return (Math.Round(item, 2)).ToString() + "M";
            }
            else if (t < 1099511627776  && t >= 1073741824)
            {
                item = t / 1073741824;
                return (Math.Round(item, 2)).ToString() + "G";
            }
            return "0";
        }

        Model.ViewData.File IFileBLL.Add(Model.ViewData.File file)
        {
            var File = DataToEntity(file);
            File = FilDAL.Add(File);
            if(File.Id != 0)
            {
                return DataToView(File);
            }
            else
            {
                return null;
            }
        }

        protected override Flie DataToEntity(Model.ViewData.File t)
        {
            if (t == null) return null;
            Model.Entity.Flie vFile = new Model.Entity.Flie();
            vFile.Id = t.Id;
            vFile.Name = t.Name;
            vFile.UserId = t.UserId;
            vFile.FolderId = t.FolderId;
            vFile.FileContentId = t.FileContentId;
            vFile.Size = Convert.ToInt32(t.Size);
            vFile.Type = t.Type;
            vFile.UpdateTime = t.UpdateTime;
            return vFile;
        }
    }
}
