using MoeMoeD.IBLL;
using System;
using MoeMoeD.Model.ViewData;
using MoeMoeD.IDAL;

namespace MoeMoeD.BLL
{
    public class FileContentBLL : BaseBLL<Model.ViewData.FileContent, Model.Entity.FileContent>, IFileContentBLL
    {
        private IFileContentDAL FileContentDAL { get; set; }

        public FileContentBLL(IFileContentDAL fileContentDAL) : base(fileContentDAL)
        {
            this.FileContentDAL = fileContentDAL;
        }
        public override bool DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Model.ViewData.FileContent GetById(int id)
        {
            return null;
        }

        protected override Model.Entity.FileContent DataToEntity(Model.ViewData.FileContent t)
        {
            if (t == null) return null;
            Model.Entity.FileContent fileContent = new Model.Entity.FileContent();
            fileContent.Id = t.Id;
            fileContent.MD5 = t.MD5;
            fileContent.Content = "./" + t.MD5;

            return fileContent;
        }

        public FileContent GetByMD5(string mD5)
        {
            return EntityToData(FileContentDAL.GetByMD5(mD5));
        }

        private FileContent EntityToData(MoeMoeD.Model.Entity.FileContent fileContent)
        {
            if (fileContent == null) return null;
            FileContent content = new FileContent();
            content.Id = fileContent.Id;
            content.Data = System.IO.File.Open(AppDomain.CurrentDomain.BaseDirectory + fileContent.Content, System.IO.FileMode.Open);
            content.MD5 = fileContent.MD5;

            return content;
        }

        public new FileContent Add(FileContent fileContent)
        {
            return EntityToData(FileContentDAL.Add(DataToEntity(fileContent)));
        }
    }
}
