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
        protected override Model.Entity.Folder DataToEntity(Folder t)
        {
            throw new NotImplementedException();
        }

        protected Model.ViewData.Folder DataToView(Model.Entity.Folder t)
        {
            Model.ViewData.Folder folder = new Folder();
            folder.FolderId = t.FolderId;
            folder.Id = t.Id;
            folder.Name = t.Name;
            folder.UserId = t.UserId;
            return folder;
        }

        protected IList<Model.ViewData.Folder> ListDataToView(IList<Model.Entity.Folder> t)
        {
            IList<Model.ViewData.Folder> vFolderLst = new List<Folder>();
            foreach (Model.Entity.Folder folder in t)
            {
                Model.ViewData.Folder vFolder = new Folder();
                vFolder.FolderId = folder.FolderId;
                vFolder.Id = folder.Id;
                vFolder.Name = folder.Name;
                vFolder.UserId = folder.UserId;
                vFolderLst.Add(vFolder);
            }
            return vFolderLst;
        }
    }
}
