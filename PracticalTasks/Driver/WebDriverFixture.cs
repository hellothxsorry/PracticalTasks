using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Services;

namespace PracticalTasks.Driver
{
    public class WebDriverFixture: IDisposable
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private int waitTime = int.Parse(TestDataReader.GetTestData("wait"));

        public IWebDriver Driver => driver;
        public WebDriverWait Wait => wait;  

        public WebDriverFixture()
        {            
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(waitTime));
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}