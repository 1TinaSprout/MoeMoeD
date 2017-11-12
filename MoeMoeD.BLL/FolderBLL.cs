using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeMoeD.IDAL;
using MoeMoeD.Model.ViewData;

namespace MoeMoeD.BLL
{
    public class FolderBLL : BaseBLL<Model.ViewData.Folder, Model.Entity.Folder>, IBLL.IFolderBLL
    {
        private IFolderDAL FolderDAL { get; set; }
        public FolderBLL(IFolderDAL folderDAL) : base(folderDAL)
        {
            this.FolderDAL = folderDAL;
        }

        public override bool DeleteById(int id)
        {
            Model.Entity.Folder folder = FolderDAL.GetById(id);
            return FolderDAL.Delete(folder);
        }

        public IList<Folder> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Folder> GetByFolderId(int folderId)
        {
            return ListDataToView(FolderDAL.GetByFolderId(folderId));
        }

        public IList<Folder> GetRootByUserId(int userId)
        {
            return ListDataToView(FolderDAL.GetRootByUserId(userId));
        }

        public Folder GetById(int id)
        {
            return DataToView(FolderDAL.GetById(id));
        }

        public bool UpdateNameById(int id, string name)
        {
            return FolderDAL.UpdateNameById(id, name);
        }

        public new Folder Add(Folder t)
        {
            t.UpdateTime = DateTime.Now.ToString();

            if (base.Add(t))
            {
                return t;
            }
            else
            {
                return null;
            }
        }

        public Folder GetByNameAndUserId(string name, int userId)
        {
            return DataToView(FolderDAL.GetByNameAndUserId(name, userId));
        }

        public Folder GetByNameAndFolderId(string name, int folderId)
        {
            return DataToView(FolderDAL.GetByNameAndFolderId(name, folderId));
        }

        protected override Model.Entity.Folder DataToEntity(Folder t)
        {
            if (t == null) return null;
            Model.Entity.Folder folder = new Model.Entity.Folder();
            folder.Id = t.Id;
            folder.Name = t.Name;
            folder.UpdateTime = t.UpdateTime;
            folder.FolderId = t.ParentId;
            folder.UserId = t.UserId;

            return folder;
        }

        protected Model.ViewData.Folder DataToView(Model.Entity.Folder t)
        {
            if (t == null) return null;
            Model.ViewData.Folder folder = new Folder();
            folder.Id = t.Id;
            folder.Name = t.Name;
            folder.UpdateTime = t.UpdateTime;
            folder.ParentId = t.FolderId;
            folder.UserId = t.UserId;
            return folder;
        }

        protected IList<Model.ViewData.Folder> ListDataToView(IList<Model.Entity.Folder> t)
        {
            if (t == null) return null;
            IList<Model.ViewData.Folder> vFolderLst = new List<Folder>();
            foreach (Model.Entity.Folder folder in t)
            {
                var vFolder = DataToView(folder);
                vFolderLst.Add(vFolder);
            }
            return vFolderLst;
        }


    }
}
