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
        public FolderBLL(IFolderDAL folderDAL) : base(folderDAL)
        {
        }

      

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Folder> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Folder> GetRootByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Folder GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateNameById(int id, string name)
        {
            throw new NotImplementedException();
        }
        protected override Model.Entity.Folder DataToEntity(Folder t)
        {
            throw new NotImplementedException();
        }
    }
}
