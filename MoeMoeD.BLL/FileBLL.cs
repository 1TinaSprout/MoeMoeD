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
    public class FileBLL : BaseBLL<Model.ViewData.File,Model.Entity.Flie>, IFileBLL
    {
        private IFileDAL FilDAL = null;
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
            throw new NotImplementedException();
        }

        public IList<Model.ViewData.File> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Model.ViewData.File> GetRootByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Model.ViewData.File GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Stream GetContentById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Model.ViewData.File> GetByFolderId(int folderid)
        {
            throw new NotImplementedException();
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
    }
}
