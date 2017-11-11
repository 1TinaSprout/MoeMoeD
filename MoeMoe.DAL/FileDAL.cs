using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MoeMoeD.DAL
{
    public class FlieDAL : BaseDAL<Flie>, IFileDAL
    {
        public FlieDAL(MoeMoeDEntities context) : base(context)
        {
            this.context = context;
        }

        public IList<Flie> GetByFolderId(int folderid)
        {
            IList<Flie> lstFlie = new List<Flie>();
            lstFlie = context.Flie.Where(f => f.FolderId == folderid).ToList<Flie>();
            return lstFlie;
        }

        public Flie GetById(int id)
        {
            Flie flie = context.Flie.FirstOrDefault(f => f.Id == id);
            return flie;
        }
        public Flie GetContent(int id)
        {
            Flie file = context.Flie.FirstOrDefault(f => f.Id == id);
            file.FileContent.Content = context.FileContent.FirstOrDefault<FileContent>(fc => fc.Id == file.Id).Content;
            return file;
        }

        public IList<Flie> GetByUserId(int userId)
        {
            try
            {
                IList<Flie> lstFlie = context.Flie.Where(t => t.UserId == userId && t.FolderId == 0).ToList<Flie>();
                return lstFlie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Stream GetContentById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Flie> GetRootByUserId(int userId)
        {
            try
            {
                IList<Flie> lstFlie = context.Flie.Where(t => t.UserId == userId && t.FolderId == 0).ToList<Flie>();
                return lstFlie;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool UpdateNameById(int id, string name)
        {
            Flie flie = context.Flie.Find(id);
            flie.Name = name;
            flie.UpdateTime = DateTime.Now.ToString();
            try { context.SaveChanges(); return true; } catch (Exception) { throw; }

        }
    }
}
