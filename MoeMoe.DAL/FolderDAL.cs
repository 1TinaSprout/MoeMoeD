using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace MoeMoeD.DAL
{
    public class FolderDAL : BaseDAL<Folder>, IFolderDAL
    {
        public FolderDAL(MoeMoeDEntities context):base(context)
        {
        }
        public override Folder Delete(Folder t)
        {
            return base.Delete(t);
        }
    }
}
