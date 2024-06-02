using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Webdriver_17_Huy_32_Phat
{
    public partial class Form1 : Form
    {
        private ChromeDriverService chromeDriverService;
        private ChromeDriver chromeDriver; // Khai báo ChromeDriver ở mức độ lớp để sử dụng trong toàn bộ class
        private bool isPlaying = true; // Biến kiểm tra trạng thái video đang chạy hay đã dừng


        public Form1()
        {
            InitializeComponent();
            // Khởi tạo ChromeDriverService để ẩn cửa sổ dòng lệnh
            chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnstart_17_32_Click(object sender, EventArgs e)
        {
            // Khởi tạo ChromeDriver và gán vào biến lớp chromeDriver
            chromeDriver = new ChromeDriver();
            chromeDriver.Url = "https://www.youtube.com/";
            chromeDriver.Navigate();

        }

        private void txts_17_32_TextChanged(object sender, EventArgs e)
        {

        }


        private void btns_17_Huy_32_Phat_Click(object sender, EventArgs e)
        {
            if (chromeDriver == null)
            {
                MessageBox.Show("Vui lòng bắt đầu trình duyệt trước khi tìm kiếm.");
                return;
            }

            // Tìm đối tượng nút tìm kiếm trên trang web
            IWebElement searchIcon = chromeDriver.FindElement(By.CssSelector("#search-icon-legacy > yt-icon > yt-icon-shape > icon-shape > div"));

            // Nhấp vào nút tìm kiếm
            searchIcon.Click();

            // Tìm đối tượng ô tìm kiếm
            IWebElement searchBar = chromeDriver.FindElement(By.Name("search_query"));

            // Xóa nội dung hiện có trong ô tìm kiếm
            searchBar.Clear();

            // Lấy nội dung từ TextBox và tách thành một mảng các từ
            string[] searchTerms = txts_17_32.Text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Ghép các từ lại thành một chuỗi, cách nhau bởi dấu cách
            string searchTerm = string.Join(" ", searchTerms);

            // Gửi giá trị tìm kiếm vào ô tìm kiếm
            searchBar.SendKeys(searchTerm);

            // Thực hiện tìm kiếm bằng cách gửi sự kiện submit
            searchBar.Submit();
        }

        private void btnstop_17_32_Click(object sender, EventArgs e)
        {
            if (chromeDriver == null)
            {
                MessageBox.Show("Vui lòng bắt đầu trình duyệt trước khi dừng hoặc tiếp tục video.");
                return;
            }

            try
            {
                // Thực hiện JavaScript để dừng hoặc tiếp tục video dựa trên trạng thái hiện tại
                IJavaScriptExecutor js = (IJavaScriptExecutor)chromeDriver;
                if (isPlaying)
                {
                    js.ExecuteScript("document.querySelector('video').pause();");
                }
                else
                {
                    js.ExecuteScript("document.querySelector('video').play();");
                }
                isPlaying = !isPlaying; // Thay đổi trạng thái của video
            }
            catch (NoSuchElementException ex)
            {
                MessageBox.Show("Không tìm thấy phần tử: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }


        private void btnvideo_17_32_Click(object sender, EventArgs e)
        {
            if (chromeDriver == null)
            {
                MessageBox.Show("Vui lòng bắt đầu trình duyệt trước khi chọn video.");
                return;
            }

            try
            {
                // Kiểm tra xem đã tìm kiếm và có kết quả trả về hay không
                var searchResults = chromeDriver.FindElements(By.CssSelector(".text-wrapper.style-scope.ytd-video-renderer"));
                if (searchResults.Count > 0)
                {
                    // Chọn video đầu tiên từ kết quả tìm kiếm
                    searchResults[0].Click();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy kết quả video trong kết quả tìm kiếm.");
                }
            }
            catch (NoSuchElementException ex)
            {
                MessageBox.Show("Không tìm thấy phần tử video: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private bool zoomvideo = false; // Biến kiểm tra trạng thái video đã được phóng to hay chưa
        private void btnzoom_17_32_Click(object sender, EventArgs e)
        {
            if (chromeDriver == null)
            {
                MessageBox.Show("Vui lòng bắt đầu trình duyệt trước khi chọn video.");
                return;
            }

            try
            {
                // Đảm bảo trình phát video đã được load
                var videoPlayer = chromeDriver.FindElement(By.CssSelector(".html5-video-player"));

                if (videoPlayer != null)
                {
                    // Kiểm tra trạng thái của video
                    var fullscreenButton = chromeDriver.FindElement(By.CssSelector(".ytp-fullscreen-button"));
                    if (fullscreenButton != null)
                    {
                        // Thực hiện hành động phóng to hoặc thu nhỏ
                        fullscreenButton.Click();
                        zoomvideo = !zoomvideo; // Đảo ngược trạng thái của biến isVideoExpanded
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nút phóng to trên trình phát video.");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy trình phát video.");
                }
            }
            catch (NoSuchElementException ex)
            {
                MessageBox.Show("Không tìm thấy phần tử video: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        // Đảm bảo ChromeDriver được giải phóng đúng cách khi đóng form
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (chromeDriver != null)
            {
                chromeDriver.Quit();
                chromeDriver.Dispose();
            }
        }
    }
}
