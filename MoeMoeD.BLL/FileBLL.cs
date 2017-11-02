using System;
using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
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

        protected override Model.Entity.Flie DataToEntity(Model.ViewData.File t)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteById(int id)
        {
            Flie flie = FilDAL.GetById(id);
            return FilDAL.Delete(flie);
        }

        public IList<Model.ViewData.File> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Model.ViewData.File> GetRootByUserId(int userId)
        {
            return ListDataToView(FilDAL.GetRootByUserId(userId));
        }

        public Model.ViewData.File GetById(int id)
        {
            return DataToView(FilDAL.GetById(id));
        }

        public Stream GetContentById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Model.ViewData.File> GetByFolderId(int folderid)
        {
            IList<Flie> flie = FilDAL.GetByFolderId(folderid);
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
            IList<Model.ViewData.File> vFileLst = new List<Model.ViewData.File>();
            foreach (Model.Entity.Flie file in t)
            {
                Model.ViewData.File vFile = new Model.ViewData.File();
                vFile.FolderId = file.FolderId;
                vFile.Id = file.Id;
                vFile.Name = file.Name;
                vFile.Size = DataSizeToView(file.Size);
                vFile.UserId = file.UserId;
                vFileLst.Add(vFile);
            }
            return vFileLst;
        }

        protected Model.ViewData.File DataToView(Flie t)
        {
            Model.ViewData.File vFile = new Model.ViewData.File();
            vFile.FolderId = t.FolderId;
            vFile.Id = t.Id;
            vFile.Name = vFile.Name;
            vFile.Size = DataSizeToView(t.Size);
            vFile.Type = t.Type;
            vFile.UpdateTime = t.UpdateTime;
            vFile.UserId = t.UserId;
            return vFile;
        }

        private string DataSizeToView(int t)
        {
            double item = 0;
            if (t < 1024 && t >= 0)
            {
                return (t).ToString() + "K";
            }
            else if (t < 1048576 && t >= 1024)
            {
                item = t / 1024;
                return (Math.Round(item, 2)).ToString() + "M";
            }
            else if (t < 100000000 && t > 1048576)
            {
                item = t / 1048576;
                return (Math.Round(item, 2)).ToString() + "G";
            }
            return "0";
        }
    }
}
