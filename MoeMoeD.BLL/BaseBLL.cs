using MoeMoeD.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.BLL
{
    public class BaseBLL<T> : IBaseBLL<T> where T:class
    {
        public T Add(T t)
        {
            throw new NotImplementedException();
        }

        public T DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> SelectById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(T t)
        {
            throw new NotImplementedException();
        }
    }
}
