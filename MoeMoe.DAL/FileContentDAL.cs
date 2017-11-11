using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class FileContentDAL : BaseDAL<FileContent>, IFileContentDAL
    {
        public FileContentDAL(MoeMoeDEntities context) : base(context)
        {
            this.context = context;
        }

        public FileContent GetById(int id)
        {
            try
            {
                FileContent fileCon = context.FileContent.FirstOrDefault<FileContent>(fc => fc.Id == id);
                return fileCon;
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
    }
}
