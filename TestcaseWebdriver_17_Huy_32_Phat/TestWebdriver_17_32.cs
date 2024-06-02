using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace TestCaseWebdriver_17_Huy_32_Phat
{
    [TestClass]
    public class TestWebdriver_17_32
    {
        private ChromeDriverService chromeDriverService;
        private ChromeDriver chromeDriver;

        [TestInitialize]
        public void SetUp()
        {
            // Khởi tạo ChromeDriver
            chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            chromeDriver = new ChromeDriver(chromeDriverService);
        }

        [TestMethod]
        public void Test_btnstart_17_32_Click()
        {
            // Navigate to YouTube
            chromeDriver.Url = "https://www.youtube.com/";
            chromeDriver.Navigate();
            Thread.Sleep(2000); // Điều hướng tới YouTube

            // Khẳng định URLL
            Assert.AreEqual("https://www.youtube.com/", chromeDriver.Url, "Trình duyệt không điều hướng đến YouTube thành công.");
        }

        [TestMethod]
        public void Test_btns_17_Huy_32_Phat_Click()
        {
            // Khởi động trình duyệt và điều hướng đến YouTube
            Test_btnstart_17_32_Click();

            // Thực hiện tìm kiếm
            var searchIcon = chromeDriver.FindElement(By.CssSelector("#search-icon-legacy > yt-icon > yt-icon-shape > icon-shape > div"));
            searchIcon.Click();
            var searchBar = chromeDriver.FindElement(By.Name("search_query"));
            searchBar.Clear();
            searchBar.SendKeys("Doraemon");
            searchBar.Submit();
            Thread.Sleep(2000); // Chờ kết quả tìm kiếm

            // Khẳng định kết quả tìm kiếm
            var results = chromeDriver.FindElements(By.CssSelector(".text-wrapper.style-scope.ytd-video-renderer"));
            Assert.IsTrue(results.Count > 0, "Không tìm thấy kết quả tìm kiếm.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Test_btnstop_17_32_Click()
        {
            // Điều hướng đến YouTube
            chromeDriver.Url = "https://www.youtube.com/";
            chromeDriver.Navigate();
            Thread.Sleep(2000); // Chờ trang tải

            // Thực hiện tìm kiếm video
            var searchIcon = chromeDriver.FindElement(By.CssSelector("#search-icon-legacy > yt-icon > yt-icon-shape > icon-shape > div"));
            searchIcon.Click();
            var searchBar = chromeDriver.FindElement(By.Name("search_query"));
            searchBar.Clear();
            searchBar.SendKeys("Doraemon");
            searchBar.Submit();
            Thread.Sleep(2000); // Chờ kết quả tìm kiếm

            // Nhấp vào kết quả video đầu tiên
            var searchResults = chromeDriver.FindElements(By.CssSelector(".text-wrapper.style-scope.ytd-video-renderer"));
            searchResults[0].Click();
            Thread.Sleep(2000); // Chờ video tải

            // Dừng video
            var js = (IJavaScriptExecutor)chromeDriver;
            js.ExecuteScript("document.querySelector('video').pause();");
            Thread.Sleep(1000);

            // Kiểm tra video đã dừng
            bool isVideoPaused = (bool)js.ExecuteScript("return document.querySelector('video').paused;");
            Assert.IsTrue(isVideoPaused, "Video không dừng.");

            // Phát lại video
            js.ExecuteScript("document.querySelector('video').play();");
            Thread.Sleep(1000);

            // Kiểm tra video đang phát
            bool isVideoPlaying = !(bool)js.ExecuteScript("return document.querySelector('video').paused;");
            Assert.IsTrue(isVideoPlaying, "Video không phát lại.");
            Thread.Sleep(2000); // Chờ video tải
        }

        [TestMethod]
        public void Test_btnvideo_17_32_Click()
        {
            // Khởi động trình duyệt và thực hiện tìm kiếm
            Test_btns_17_Huy_32_Phat_Click();

            // Click vào kết quả video đầu tiên
            var searchResults = chromeDriver.FindElements(By.CssSelector(".text-wrapper.style-scope.ytd-video-renderer"));
            searchResults[0].Click();
            Thread.Sleep(2000);

            // Khẳng định trang video đã được tải
            var videoTitle = chromeDriver.FindElement(By.CssSelector(".title.style-scope.ytd-video-primary-info-renderer"));
            Assert.IsNotNull(videoTitle, "Video không tải thành công.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void Test_btnzoom_17_32_Click()
        {
            // Khởi động trình duyệt và phát video
            Test_btnvideo_17_32_Click();

            // Zoom video
            var fullscreenButton = chromeDriver.FindElement(By.CssSelector(".ytp-fullscreen-button"));
            fullscreenButton.Click();
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Dọn dẹp và đóng trình duyệt
            if (chromeDriver != null)
            {
                chromeDriver.Quit();
                chromeDriver.Dispose();
            }
        }

    }
}
