using MoeMoeD.Model.Entity;
using System;
using System.Collections.Generic;

namespace MoeMoeD.IDAL
{
    public interface IFolderDAL : IBaseDAL<Folder>
    {
        //根据UserId查出此用户的所有Folder
        IList<Folder> GetByUserId(int userId);
        IList<Folder> GetByFolderId(int folderId);
        //根据UserId查出此用户Root目录下的所有Folder
        IList<Folder> GetRootByUserId(int userId);

        //根据Id查出Folder
        Folder GetById(int id);

        bool UpdateNameById(int id, String name);

        Folder GetByNameAndUserId(string name, int userId);

        Folder GetByNameAndFolderId(string name, int folderId);
    }
}
