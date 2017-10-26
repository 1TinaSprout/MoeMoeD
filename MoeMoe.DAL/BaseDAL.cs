using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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

        public virtual bool Add(T t)
        {
            context.Set<T>().Add(t);
            context.SaveChanges();

            return true;
        }

        public virtual bool Delete(T t)
        {
            context.Set<T>().Remove(t);
            context.SaveChanges();

            return true;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>> where)
        {
            return context.Set<T>().Where(where);
        }

        public virtual bool Update(T t)
        {
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();

            return true;
        }
    }
}
