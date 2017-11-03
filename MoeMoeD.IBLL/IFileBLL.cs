using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;

namespace MoeMoeD.IBLL
{
    public interface IFileBLL : IBaseBLL<File>
    {
        //根据UserId查出此用户的所有File
        IList<File> GetByUserId(int userId);

        //根据UserId查出此用户Root目录下的所有File
        IList<File> GetRootByUserId(int userId);

        //根据Id查出文件
        File GetById(int id);

        //根据Id查出文件的内容
        System.IO.Stream GetContentById(int id);

        //根据Id查出文件的内容
        IList<File> GetByFolderId(int folderid);

        bool UpdateNameById(int id, String name);

        bool IsContains(byte[] MD5);
    }
}
