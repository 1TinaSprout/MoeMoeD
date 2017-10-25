using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IDAL
{
    public interface IUserDAL
    {
        User GetUserByPhone(String phone);
        User GetUserByName(String name);
        User GetUserByEmail(String email);
    }
}
