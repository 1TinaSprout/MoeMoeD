using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IDAL
{
    public interface IBaseDAL<T> where T : class
    {
        bool Add(T t);
        T Delete(T t);
        IQueryable<T> Select(Func<T, bool> where);
        bool Update(T t);
    }
}
