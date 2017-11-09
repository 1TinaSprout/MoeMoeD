using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoeMoeD.DAL;

namespace MoeMoeD.Test.DAL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var folder = new Model.Entity.Folder() { FolderId = 1, UserId = 1, Name = "111", UpdateTime = DateTime.Now.ToShortDateString() };
            new FolderDAL(new Model.Entity.MoeMoeDEntities()).Add(folder);

            return;

        }
    }
}
