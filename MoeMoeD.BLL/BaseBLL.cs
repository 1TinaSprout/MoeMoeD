using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.BLL
{
    public abstract class BaseBLL<D, E> : IBaseBLL<D> where D : class where E : class, new()
    {
        public MoeMoeD.IDAL.IBaseDAL<E> BaseDAL { get; set; }
        public BaseBLL(MoeMoeD.IDAL.IBaseDAL<E> baseDAL)
        {
            this.BaseDAL = baseDAL;
        }
        public virtual bool Add(D t)
        {
            return BaseDAL.Add(DataToEntity(t));
        }

        public abstract bool DeleteById(int id);

        public virtual bool Update(D t)
        {
            return BaseDAL.Update(DataToEntity(t));
        }

        protected abstract E DataToEntity(D t);
    }
}
