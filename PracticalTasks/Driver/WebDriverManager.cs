using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PracticalTasks.Driver
{
    public class WebDriverManager
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();

        private WebDriverManager() { }

        public static IWebDriver GetInstance()
        {
            var browser = Environment.GetEnvironmentVariable("browser") ?? "chrome";
            browser = browser.Trim();

            switch (browser)
            {
                case "firefox":
                    driver.Value = new FirefoxDriver();
                    break;
                case "chrome":
                    driver.Value = new ChromeDriver();
                    break;
                default:
                    driver.Value = new ChromeDriver();
                    break;
            }

            driver.Value.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
            driver.Value.Manage().Window.Maximize();

            return driver.Value;
        }
    }
}
