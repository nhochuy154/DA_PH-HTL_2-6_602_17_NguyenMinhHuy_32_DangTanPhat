using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nunit_17_Huy_32_Phat;
using System;
using System.Text;

namespace TestPT2_17_Huy_32_Phat
{
    [TestClass]
    public class TestPT2_17_32
    {
        public TestContext TestContext { get; set; }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void TestPT2()
        {

            // Trích xuất dữ liệu kiểm tra từ dòng hiện tại của tệp CSV
            float a = float.Parse(TestContext.DataRow[0].ToString());
            float b = float.Parse(TestContext.DataRow[1].ToString());
            float c = float.Parse(TestContext.DataRow[2].ToString());
            string expected = TestContext.DataRow[3].ToString();

            // Chuyển đổi chuỗi sang mã UTF-8
            byte[] expectedBytes = Encoding.Default.GetBytes(expected);
            expected = Encoding.UTF8.GetString(expectedBytes);

            // Gọi phương thức được kiểm tra với dữ liệu đầu vào
            string actual = Giaipt_17_32.giaiB2(a, b, c);

            // Kiểm tra kết quả
            Assert.AreEqual(expected, actual);
        }
    }
}
