using MoeMoeD.IBLL;
using MoeMoeD.IDAL;
using MoeMoeD.Model.ViewData;
using System;

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
            if (t == null) return null;
            Model.ViewData.User eUser = new Model.ViewData.User();

            eUser.Email = t.Email;
            eUser.Id = t.Id;
            eUser.Name = t.Name;
            eUser.Password = t.Password;
            return eUser;
        }

        protected override Model.Entity.User DataToEntity(User t)
        {
            if (t == null) return null;
            throw new NotImplementedException();
        }
    }
}
