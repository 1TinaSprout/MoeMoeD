using MoeMoeD.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T:class
    {
        public T Add(T t)
        {
            throw new NotImplementedException();
        }

        public T Delete(T t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Select(Func<T, bool> where)
        {
            throw new NotImplementedException();
        }

        public bool Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
