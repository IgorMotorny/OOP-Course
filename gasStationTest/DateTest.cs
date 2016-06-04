using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GasStation;
namespace gasStationTest {
    [TestClass]
    public class DateTest {
        [TestMethod]
        public void ToString_Short_Formated() {
            Date date = new Date(2, 2, 2020);
            String dateToString = date.ToString();
            Assert.AreEqual("02.02.2020", dateToString);
        }
        [TestMethod]
        public void ToString_Long_Formated() {
            Date date = new Date(12, 12, 2020);
            String dateToString = date.ToString();
            Assert.AreEqual("12.12.2020", dateToString);
        }
    }
}
