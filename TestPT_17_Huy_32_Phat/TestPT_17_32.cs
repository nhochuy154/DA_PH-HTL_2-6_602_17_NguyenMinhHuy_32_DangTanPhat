using Nunit_17_Huy_32_Phat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPT_17_Huy_32_Phat
{
    [TestClass]
    public class TestPT_17_32
    {
        [TestMethod]
        public void Test_giaiB1_VoSoNghiem()
        {
            // Arrange
            float a = 0;
            float b = 0;
            string expected = "PTB1 Vô số nghiệm";

            // Act
            string actual = Giaipt_17_32.giaiB1(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_giaiB1_VoNghiem()
        {
            // Arrange
            float a = 0;
            float b = 5;
            string expected = "PTB1 Vô nghiệm";

            // Act
            string actual = Giaipt_17_32.giaiB1(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_giaiB1_CoNghiem()
        {
            // Arrange
            float a = 2;
            float b = -4;
            string expected = "2";

            // Act
            string actual = Giaipt_17_32.giaiB1(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_giaiB2_VoNghiem()
        {
            // Arrange
            float a = 1;
            float b = 2;
            float c = 3;
            string expected = "PTB2 Vô nghiệm";

            // Act
            string actual = Giaipt_17_32.giaiB2(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_giaiB2_NghiemKep()
        {
            // Arrange
            float a = 1;
            float b = -2;
            float c = 1;
            string expected = "x1=x2=1";

            // Act
            string actual = Giaipt_17_32.giaiB2(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_giaiB2_HaiNghiemPhanBiet()
        {
            // Arrange
            float a = -2;
            float b = 4;
            float c = 2;
            string expected = "x1=-0.4142136  x2=2.414214";

            // Act
            string actual = Giaipt_17_32.giaiB2(a, b, c);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
