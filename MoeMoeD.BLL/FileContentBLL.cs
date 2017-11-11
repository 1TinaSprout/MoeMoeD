using MoeMoeD.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeMoeD.Model.Entity;
using MoeMoeD.Model.ViewData;
using MoeMoeD.IDAL;

namespace MoeMoeD.BLL
{
    public class FileContentBLL : BaseBLL<Model.ViewData.FileContent, Model.Entity.FileContent>, IFileContentBLL
    {
        private IFileContentDAL FileContentDAL { get; set; }
        public FileContentBLL(IFileContentDAL fileContentDAL) : base(fileContentDAL)
        {
            this.FileContentDAL = fileContentDAL;
        }
        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Model.ViewData.FileContent GetById(int id)
        {
            return null;
        }

        protected override Model.Entity.FileContent DataToEntity(Model.ViewData.FileContent t)
        {
            throw new NotImplementedException();
        }
    }
}
