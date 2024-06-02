using Nunit_17_Huy_32_Phat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TestPT1_17_Huy_32_Phat
{
    [TestClass]
    public class TestPT1_17_32
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestPT1()
        {

            // Trích xuất dữ liệu kiểm tra từ dòng hiện tại của tệp CSV
            float a = float.Parse(TestContext.DataRow[0].ToString());
            float b = float.Parse(TestContext.DataRow[1].ToString());
            string expected = TestContext.DataRow[2].ToString();

            // Chuyển đổi chuỗi sang mã UTF-8
            byte[] expectedBytes = Encoding.Default.GetBytes(expected);
            expected = Encoding.UTF8.GetString(expectedBytes);

            // Gọi phương thức được kiểm tra với dữ liệu đầu vào
            string actual = Giaipt_17_32.giaiB1(a, b);

            // Kiểm tra kết quả
            Assert.AreEqual(expected, actual);
        }

    } 
}
