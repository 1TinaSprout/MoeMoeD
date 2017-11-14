using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.Model.ViewData
{
    public class File
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FolderId { get; set; }
        public int FileContentId { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public String UpdateTime { get; set; }
        public String Size { get; set; }
    }
}
