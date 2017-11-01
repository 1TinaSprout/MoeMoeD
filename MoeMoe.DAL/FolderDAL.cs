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
        public FolderDAL(MoeMoeDEntities context):base(context)
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
    }
}
