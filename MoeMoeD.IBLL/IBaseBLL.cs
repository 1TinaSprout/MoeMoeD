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
        bool Add(D t);
        bool DeleteById(int id);
        bool Update(D t);
    }
}
