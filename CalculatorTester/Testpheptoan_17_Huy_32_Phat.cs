using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nunit_17_Huy_32_Phat;
using System;

namespace CalculatorTesterPhepToan_17_Huy_32_Phat
{
    [TestClass]
    public class Testpheptoan_17_Huy_32_Phat
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestPhepToan_17_32()
        {
            int a = int.Parse(TestContext.DataRow[0].ToString());
            int b = int.Parse(TestContext.DataRow[1].ToString());
            string operation = TestContext.DataRow[2].ToString().Trim('\'');
            int expected = int.Parse(TestContext.DataRow[3].ToString());

            Calculation_17_32 c = new Calculation_17_32(a, b);
            int actual = c.Execute(operation);

            Assert.AreEqual(expected, actual);
            
        }
    }
}