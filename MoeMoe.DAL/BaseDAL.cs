using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class
    {
        public MoeMoeDEntities context { get; set; }
        public BaseDAL(MoeMoeDEntities context)
        {
            this.context = context;
        }
         
        public bool Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();

            return true;
        }

        public virtual T Delete(T t)
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
