using System;
using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace MoeMoeD.BLL
{
    public class FileBLL
    {
        [Dependency]
        public IFileDAL fileDAL { get; set; }

        public List<Flie> GetFileByFloderId(int id)
        {
            return fileDAL.GetFileByFloderId(id);
        }
        public List<Flie> GetFileByUserId(int id)
        {
            return fileDAL.GetFileByUserId(id);
        }
    }
}
