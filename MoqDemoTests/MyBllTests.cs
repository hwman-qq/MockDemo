﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}