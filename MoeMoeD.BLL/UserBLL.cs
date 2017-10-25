
using Microsoft.Practices.Unity;
using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.BLL
{
    public class UserBLL
    {
        [Dependency]
        public IUserDAL userDAL { get; set; }

        public User GetUserByPhone(String phone)
        {
            return userDAL.GetUserByPhone(phone);
        }
        public User GetUserByName(String name)
        {
            return userDAL.GetUserByName(name);
        }
        public User GetUserByEmail(String email)
        {
            return userDAL.GetUserByEmail(email);
        }

    }
}
