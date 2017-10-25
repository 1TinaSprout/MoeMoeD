using MoeMoeD.IBLL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.BLL
{
    public abstract class BaseBLL<D, E> : IBaseBLL<D>
        where D : class
        where E : class
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

        public virtual D DeleteById(int id)
        { 
            throw new NotImplementedException();
        }

        public virtual bool Update(D t)
        {
            throw new NotImplementedException();
        }

        protected abstract E DataToEntity(D t);
        protected abstract List<E> DataToEntity(List<D> t);
        protected abstract D EntityToData(E t);
        protected abstract List<D> DataToEntity(List<E> t);
    }
}
