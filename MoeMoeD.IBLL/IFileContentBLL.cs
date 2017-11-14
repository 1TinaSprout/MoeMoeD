using MoeMoeD.Model.ViewData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.IBLL
{
    public interface IFileContentBLL : IBaseBLL<FileContent>
    {
        FileContent GetById(int id);
        FileContent GetByMD5(String mD5);
        new FileContent Add(FileContent fileContent);
    }
}
