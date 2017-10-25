using Microsoft.Practices.Unity;
using MoeMoeD.IBLL;
using MoeMoeD.IDAL;
using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.BLL
{
    public class UserBLL : BaseBLL<User, Model.Entity.User>, IUserBLL
    {
        public UserBLL(IUserDAL userDAL) : base(userDAL) { }


        protected override Model.Entity.User DataToEntity(User t)
        {
            throw new NotImplementedException();
        }

        protected override List<Model.Entity.User> DataToEntity(List<User> t)
        {
            throw new NotImplementedException();
        }

        protected override User EntityToData(Model.Entity.User t)
        {
            throw new NotImplementedException();
        }

        protected override List<User> DataToEntity(List<Model.Entity.User> t)
        {
            throw new NotImplementedException();
        }
    }
}
