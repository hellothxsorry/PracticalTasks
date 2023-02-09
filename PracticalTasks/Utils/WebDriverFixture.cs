using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.PageObjects;

namespace PracticalTasks.Utils
{
    public class WebDriverFixture: IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
