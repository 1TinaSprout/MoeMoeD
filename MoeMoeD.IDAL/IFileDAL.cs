using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IDAL
{
    public interface IFileDAL
    {
        List<Flie> GetFileByFloderId(int id);
        List<Flie> GetFileByUserId(int id);
    }
}
