using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;

namespace MoeMoeD.IDAL
{
    public interface IFileDAL : IBaseDAL<Flie>
    {
        bool UpdateNameById(int id, String name);
        IList<Flie> GetByFolderId(int folderid);
        IList<Flie> GetByUserId(int userId);
        IList<Flie> GetRootByUserId(int userId);
        Flie GetById(int id);
        System.IO.Stream GetContentById(int id);
    }
    
}
