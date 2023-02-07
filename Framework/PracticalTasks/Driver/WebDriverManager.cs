using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace PracticalTasks.Driver
{
    public class WebDriverManager
    {
        private static IWebDriver driver;

        private WebDriverManager() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                var browser = Environment.GetEnvironmentVariable("browser") ?? "chrome";
                browser = browser.Trim();

                switch (browser)
                {
                    case "firefox":
                        driver = new FirefoxDriver();
                        break;
                    case "chrome":
                        driver = new ChromeDriver();
                        break;
                    default:
                        driver = new ChromeDriver();
                        break;
                }

                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
            }

            return driver;
        }
    }
}
