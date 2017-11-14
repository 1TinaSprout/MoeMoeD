using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoeMoeD.Model.ViewData
{
    public class FileContent
    {
        public int Id { get; set; }
        public String MD5 { get; set; }
        public Stream Data { get; set; }
    }
}
