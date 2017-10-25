using MoeMoeD.IDAL;
using MoeMoeD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class FileDAL : IFileDAL
    {
        public List<Flie> GetFileByFloderId(int id)
        {
            MoeMoeDEntities context = ContextFactory.GetDBContext();

            IQueryable<Flie> fileList = from value in context.Flie where value.FloderId.Equals(id) select value;

            ContextFactory.RevertDBContext(context);

            if (fileList != null && fileList.Count() > 0)
                return fileList.ToList();
            else
                return null;
        }

        public List<Flie> GetFileByUserId(int id)
        {
            MoeMoeDEntities context = ContextFactory.GetDBContext();

            IQueryable<Flie> fileList = from value in context.Flie where value.UserId.Equals(id) select value;

            ContextFactory.RevertDBContext(context);

            if (fileList != null && fileList.Count() > 0)
                return fileList.ToList();
            else
                return null;
        }
    }
}
