using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IBLL
{
    public interface IUserBLL : IBaseBLL<User>
    {
        //根据email返回User
        User GetByEmail(String email);

        //根据name返回User
        User GetByName(String name);
    }
}
