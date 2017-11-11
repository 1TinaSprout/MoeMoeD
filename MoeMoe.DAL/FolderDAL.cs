using MoeMoeD.IDAL;
using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace MoeMoeD.DAL
{
    public class FolderDAL : BaseDAL<Folder>, IFolderDAL
    {
        public FolderDAL(MoeMoeDEntities context) : base(context)
        {
            this.context = context;
        }
        public override bool Delete(Folder t)
        {
            RemoveChildFoder(t);
            RemoveChildFile(t);
            context.Set<Folder>().Remove(t);
            context.SaveChanges();
            return true;
        }
        public void RemoveChildFoder(Folder folder)
        {
            for (int i = 0; i < folder.ChildFolder.Count; i++)
            {
                RemoveChildFoder(folder);
                RemoveChildFile(folder);
                context.Set<Folder>().Remove(folder);
            }
        }

        public void RemoveChildFile(Folder folder)
        {
            for (int i = 0; i < folder.Flie.Count; i++)
            {
                Flie flie = context.Flie.Find(folder.FolderId);
                context.Flie.Remove(flie);
            }
        }

        public IList<Folder> GetByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public IList<Folder> GetRootByUserId(int userId)
        {
            try
            {
                IList<Folder> lstfolder = context.Folder.Where(f => f.UserId == userId && f.FolderId == 0).ToList<Folder>();
                return lstfolder;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Folder GetById(int id)
        {
            Folder folder = new Folder();
            try
            {
                folder = context.Folder.FirstOrDefault(f => f.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            return folder;
        }

        public bool UpdateNameById(int id, string name)
        {
            Folder folder = new Folder();
            try
            {
                folder = context.Folder.FirstOrDefault(f => f.Id == id);
                folder.Name = name;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Folder GetByName(string name)
        {
            try
            {
                Folder folder = context.Folder.FirstOrDefault(f => f.Name == name);
                return folder;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public override bool Add(Folder t)
        {
            
            base.Add(t);
            var i = GetById(t.Id);
            var user = i.User;
            return true;
        }
    }
}
