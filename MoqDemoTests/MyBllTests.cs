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
            moq.Setup(a => a.GetAll()).Returns(new List<MyDto>
            {
                new MyDto{Name="baidu",Age=15},
                new MyDto{Name="sto",Age=32},
                new MyDto{Name="zto",Age=24},
                new MyDto{Name="yto",Age=12}
            });
            MyBll bll = new MyBll(moq.Object);
            var dtos = bll.GetAllDtos().ToList();
            Assert.AreEqual<int>(2, dtos.Count);
        }

        [TestMethod()]
        public void ShouldReturn_A_Dto_If_QueryBy_Id_With_Valid_Parameter()
        {
            var moq = new Mock<IDataBaseContext<MyDto>>();
            moq.Setup(a => a.GetElementById(It.IsAny<string>())).Returns(new MyDto());

            MyBll bll = new MyBll(moq.Object);
            var dto = bll.GetADto("afakeid");

            Assert.IsNotNull(dto);
        }

        [TestMethod]
        public void ShouldReturn_True_If_Id_Is_9527()
        {
            var moq = new Mock<IDataBaseContext<MyDto>>();
            moq.Setup(a => a.GetElementById(It.Is<string>(t => t.Trim() == "9527"))).Returns(new MyDto { Name = "sto", Age = 24 });
            MyBll bll = new MyBll(moq.Object);
            bool isVip = bll.IsVip("9527");
            Assert.IsTrue(isVip);
        }

        [TestMethod]
        public void MockOf_Test()
        {
            var obj = Mock.Of<IDataBaseContext<MyDto>>(a => a.GetAll() == new List<MyDto>() { new MyDto() }
                                                           && a.GetElementById(It.IsAny<string>()) == new MyDto()
                                                           && a.GetElementsByName(It.IsAny<string>()) == new MyDto[3]);

            var all = obj.GetAll();
            var one = obj.GetElementById("s");
            var some = obj.GetElementsByName("somename");

            Assert.AreEqual(1, all.Count());
            Assert.IsNotNull(one);
            Assert.AreEqual(3, some.Count());
        }
    }
}