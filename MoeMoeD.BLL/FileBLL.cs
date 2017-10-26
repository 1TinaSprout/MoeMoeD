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

namespace MoeMoeD.BLL
{
    public class FileBLL : BaseBLL<Flie,Model.Entity.Flie>, IFileBLL
    {
        public FileBLL(IFileDAL fileDAL) : base(fileDAL) { }

        protected override Model.Entity.Flie DataToEntity(Flie t)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
