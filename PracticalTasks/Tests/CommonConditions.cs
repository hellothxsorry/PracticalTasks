using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.PageObjects;
using PracticalTasks.Utils;
using Xunit;

namespace PracticalTasks.Tests
{
    public class CommonConditions: IClassFixture<WebDriverFixture>
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;
        protected MailboxPage mailboxPage;
        protected WebDriverWait wait;
        protected ProfilePage profilePage;

        public CommonConditions(WebDriverFixture fixture)
        {
            driver = fixture.Driver;
            loginPage = new LoginPage(driver);
            mailboxPage = new MailboxPage(driver);
            profilePage = new ProfilePage(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }
    }
}
