using Microsoft.Practices.Unity;
using MoeMoeD.DAL;
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
        private IUserDAL UserDAL { get; set; }

        public UserBLL(IUserDAL userDAL) : base(userDAL)
        {
            this.UserDAL = userDAL;
        }

        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetByEmail(string email)
        {
            return DataToView(UserDAL.GetUserByEmail(email));
        }

        public User GetByName(string name)
        {
            return DataToView(UserDAL.GetUserByName(name));
        }

        protected Model.ViewData.User DataToView(Model.Entity.User t)
        {
            Model.ViewData.User eUser = new Model.ViewData.User();

            eUser.Email = t.Email;
            eUser.Id = t.Id;
            eUser.Name = t.Name;
            eUser.Name = t.Password;
            return eUser;
        }

        protected override Model.Entity.User DataToEntity(User t)
        {
            throw new NotImplementedException();
        }
    }
}
