using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoWindowsApplication;
using System.Collections.Generic;

namespace UnitTestWinApp
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DataBaseNoTEmpty()
        {
            List<Person> p = new DBConnect().SelectAll();
            Assert.AreNotEqual(p,null);
        }

        [TestMethod]
        public void DataBaseNoTEmptyForGivenId()
        {
            Person p = new DBConnect().Select(1);
            Assert.AreNotEqual(p, null);
        }
    }
}
