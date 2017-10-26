using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IDAL
{
    public interface IBaseDAL<T> where T : class
    {
        bool Add(T t);
        bool Delete(T t);
        IQueryable<T> Select(Expression<Func<T, bool>> where);
        bool Update(T t);
    }
}
