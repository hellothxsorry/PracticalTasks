using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.PageObjects;

namespace PracticalTasks.Utils
{
    public class WebDriverFixture: IDisposable
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;
        public LoginPage LoginPage;
        public MailboxPage MailboxPage;
        public ProfilePage ProfilePage;

        public WebDriverFixture()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            Driver = new ChromeDriver(options);
            MailboxPage = new MailboxPage(Driver);
            LoginPage = new LoginPage(Driver);
            ProfilePage = new ProfilePage(Driver);
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(60));
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
