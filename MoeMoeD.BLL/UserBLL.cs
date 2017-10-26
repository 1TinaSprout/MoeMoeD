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

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        protected override Model.Entity.User DataToEntity(User t)
        {
            throw new NotImplementedException();
        }
    }
}
