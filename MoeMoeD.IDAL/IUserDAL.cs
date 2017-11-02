using MoeMoeD.Model;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IDAL
{
    public interface IUserDAL : IBaseDAL<MoeMoeD.Model.Entity.User>
    {
        User GetUserByEmail(string email);
        User GetUserByName(string name);
    }
}
