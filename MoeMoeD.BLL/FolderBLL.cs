using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using MoeMoeD.Model.ViewData;

namespace MoeMoeD.BLL
{
    public class FolderBLL : BaseBLL<Model.ViewData.Folder, Model.Entity.Folder>, IBLL.IFolderBLL
    {
        public FolderBLL(IFolderDAL folderDAL) : base(folderDAL)
        {
        }

        protected override List<Model.ViewData.Folder> DataToEntity(List<Model.Entity.Folder> t)
        {
            throw new NotImplementedException();
        }

        protected override List<Model.Entity.Folder> DataToEntity(List<Model.ViewData.Folder> t)
        {
            throw new NotImplementedException();
        }

        protected override Model.Entity.Folder DataToEntity(Model.ViewData.Folder t)
        {
            throw new NotImplementedException();
        }

        protected override Model.ViewData.Folder EntityToData(Model.Entity.Folder t)
        {
            throw new NotImplementedException();
        }
    }
}
