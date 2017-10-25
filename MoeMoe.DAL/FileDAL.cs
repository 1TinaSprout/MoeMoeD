using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.DAL
{
    public class FlieDAL : BaseDAL<Flie>, IFileDAL
    {
        public List<Flie> GetFileByFloderId(int id)
        {
            MoeMoeDEntities context = ContextFactory.GetDBContext();

            IQueryable<Flie> fileList = from value in context.Flie where value.FolderId.Equals(id) select value;

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
