using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.Model.ViewData
{
    public class File : BaseData
    {
        public String Name { get; set; }
        public String Type { get; set; }
        public String UpdateTime { get; set; }
        public String Size { get; set; }
        public int FolderId { get; set; }
        public int UserId { get; set; }
    }
}
