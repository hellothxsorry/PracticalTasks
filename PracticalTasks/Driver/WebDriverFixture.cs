using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PracticalTasks.Driver
{
    public class WebDriverFixture: IDisposable
    {
        public IWebDriver Driver { get; set; }

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
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
