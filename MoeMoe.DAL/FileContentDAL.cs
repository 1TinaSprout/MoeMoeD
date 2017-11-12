using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Linq;

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

        public FileContent GetByMD5(string mD5)
        {
            var list = from value in context.FileContent where value.MD5 == mD5 select value;
            if(list != null && list.Count() > 0)
            {
                return list.FirstOrDefault();
            }
            return null;
        }

        FileContent IFileContentDAL.Add(FileContent fileContent)
        {
            context.FileContent.Attach(fileContent);
            context.FileContent.Add(fileContent);
            context.SaveChanges();

            return fileContent;
        }
    }
}
