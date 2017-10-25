using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class FlieDAL : BaseDAL<Flie>, IFileDAL
    {
        public FlieDAL(MoeMoeDEntities context) : base(context)
        {
        }
    }
}
