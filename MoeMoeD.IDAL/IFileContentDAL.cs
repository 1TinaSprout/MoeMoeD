using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoeMoeD.IDAL
{
    public interface IFileContentDAL : IBaseDAL<FileContent>
    {
        FileContent GetById(int id);
    }
}
