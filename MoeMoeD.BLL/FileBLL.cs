using System;
using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MoeMoeD.Model.ViewData;

namespace MoeMoeD.BLL
{
    public class FileBLL : BaseBLL<Flie>
    {
        [Dependency]
        public IFileDAL fileDAL { get; set; }

     
    }
}
