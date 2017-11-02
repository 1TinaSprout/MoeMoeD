using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoeMoeD.BLL;
using MoeMoeD.DAL;

namespace MoeMoeD.Test.DAL
{
    /// <summary>
    /// UserTest 的摘要说明
    /// </summary>
    [TestClass]
    public class UserTest
    {
        public UserTest()
        {
            //
            //TODO:  在此处添加构造函数逻辑
            //
        }

        [TestMethod]
        public void TestMethod1()
        {
            var user = new UserBLL(new UserDAL(new Model.Entity.MoeMoeDEntities())).GetByEmail("123456@qq.com");
            return;
        }
    }
}
