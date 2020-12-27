using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MoqDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo.Tests
{
    [TestClass()]
    public class MyBllTests
    {
        [TestMethod()]
        public void SimpleTest()
        {
            var moq = new Mock<IDataBaseContext<MyDto>>();
            MyBll bll = new MyBll(moq.Object);
            var result = bll.GetADto(null);
            Assert.IsNull(result);
        }

        [TestMethod()]
        public void ShouldReturn_A_Collection_Of_Dtos()
        {
            var moq = new Mock<IDataBaseContext<MyDto>>();
            MyBll bll = new MyBll(moq.Object);
            var dtos = bll.GetDtos("sto");
        }
    }
}