using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace PracticalTasks.Driver
{
    public class WebDriverFixture: IDisposable
    {
        public IWebDriver Driver { get; private set; }
        public WebDriverWait Wait { get; private set; }

        public WebDriverFixture()
        {
            var browser = Environment.GetEnvironmentVariable("browser") ?? "chrome";
            browser = browser.Trim();

            switch (browser)
            {
                case "firefox":
                    Driver = new FirefoxDriver();
                    break;
                case "chrome":
                    Driver = new ChromeDriver();
                    break;
                default:
                    Driver = new ChromeDriver();
                    break;
            }

            Driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            Driver.Manage().Window.Maximize();
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
        }

        public void Dispose()
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var screenshotsDirectory = Path.Combine(directory, "Screenshots");
            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }
            var filePath = Path.Combine(screenshotsDirectory, $"{screenshotName}.png");

            try
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error occured while taking screenshot: {exception.Message}");
            }

            Driver.Quit();
            Driver.Dispose();
        }
    }
}
