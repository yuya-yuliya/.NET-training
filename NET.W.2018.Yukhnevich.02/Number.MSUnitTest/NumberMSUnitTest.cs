using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Number;

namespace Number.MSUnitTest
{
    [TestClass]
    public class NumberMSUnitTest
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", 
            "MSTestData.xml", 
            "InsertNumber",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void Number_InsertNumber_FromXML()
        {
            int numberSource = Convert.ToInt32(TestContext.DataRow["numberSource"]);
            int numberIn = Convert.ToInt32(TestContext.DataRow["numberIn"]);
            int startBit = Convert.ToInt32(TestContext.DataRow["startBit"]);
            int endBit = Convert.ToInt32(TestContext.DataRow["endBit"]);
            int expected = Convert.ToInt32(TestContext.DataRow["expected"]);

            int result = Numbers.InsertNumber(numberSource, numberIn, startBit, endBit);

            Assert.AreEqual(expected, result);
        }
    }
}
