using Nunit_17_Huy_32_Phat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace TestSNT_17_Huy_32_Phat
{
    [TestClass]
    public class TestSNT_17_32
    {
            public TestContext TestContext { get; set; }

            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\Data\TestData.csv", "TestData#csv", DataAccessMethod.Sequential)]
            [TestMethod]
            public void TestSNT()
            {

            // Trích xuất dữ liệu kiểm tra từ dòng hiện tại của tệp CSV
            int a = int.Parse(TestContext.DataRow[0].ToString());
            string expected = TestContext.DataRow[1].ToString();

            // Chuyển đổi chuỗi sang mã UTF-8
            byte[] expectedBytes = Encoding.Default.GetBytes(expected);
            expected = Encoding.UTF8.GetString(expectedBytes);

            // Gọi phương thức được kiểm tra với dữ liệu đầu vào
            string actual = Songuyento_17_32.Songuyento_17_Huy_32_Phat(a);

            // Kiểm tra kết quả
            Assert.AreEqual(expected, actual);
        }
        }
    }
