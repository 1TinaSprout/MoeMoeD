using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.Model.ViewData
{
    public class Folder
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int UserId { get; set; }
        public String Name { get; set; }
        public String UpdateTime { get; set; }
    }
}
