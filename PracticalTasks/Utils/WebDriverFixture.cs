using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PracticalTasks.PageObjects;

namespace PracticalTasks.Utils
{
    public class WebDriverFixture: IDisposable
    {
        public IWebDriver Driver;
        public LoginPage LoginPage;
        public MailboxPage MailboxPage;

        public WebDriverFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            MailboxPage = new MailboxPage(Driver);
            LoginPage = new LoginPage(Driver);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
