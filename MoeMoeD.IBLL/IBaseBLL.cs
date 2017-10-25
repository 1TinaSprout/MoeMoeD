using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IBLL
{
    public interface IBaseBLL<D> where D:class
    {
        D Add(D t);
        D DeleteById(int id);
        bool Update(D t);
    }
}
