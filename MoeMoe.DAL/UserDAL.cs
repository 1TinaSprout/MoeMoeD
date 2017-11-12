using MoeMoeD.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoeMoeD.Model;
using MoeMoeD.Model.Entity;

namespace MoeMoeD.DAL
{
    public class UserDAL : BaseDAL<User>,IUserDAL
    {
        public UserDAL(MoeMoeDEntities context) : base(context)
        {
        }

        public User GetUserByEmail(string email)
        {
            IQueryable<User> userList = from value in context.User
                                        where value.Email.Equals(email)
                                        select value;

            if (userList != null && userList.Count() > 0)
                return userList.FirstOrDefault<User>();
            else
                return null;
        }

        public User GetUserByName(string name)
        {
            var userList = from value in context.User where value.Name.Equals(name) select value;
            if (userList != null && userList.Count() > 0)
                return userList.FirstOrDefault<User>();
            else
                return null;
        }

        public User GetUserByPhone(string phone)
        {
            var userList = from value in context.User where value.Email.Equals(phone) select value;

            if (userList != null && userList.Count() > 0)
                return userList.FirstOrDefault<User>();
            else
                return null;
        }
    }
}
