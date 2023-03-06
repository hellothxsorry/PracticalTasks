using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Driver;
using PracticalTasks.Models;
using PracticalTasks.PageObjects;
using PracticalTasks.Services;
using Xunit;

namespace PracticalTasks.Tests
{
    public class CommonConditions: IClassFixture<WebDriverFixture>
    {
        protected WebDriverFixture fixture;
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected LoginPage loginPage;
        protected MailboxPage mailboxPage;
        protected ProfilePage profilePage;
        protected User userOne;
        protected User userTwo;
        protected User incorrectUser;
        protected Email emailOne;
        protected Email emailTwo;

        public CommonConditions(WebDriverFixture fixture)
        {
            this.fixture = fixture;
            driver = fixture.Driver;
            wait = fixture.Wait;
            loginPage = new LoginPage(driver, wait);
            mailboxPage = new MailboxPage(driver, wait);
            profilePage = new ProfilePage(driver, wait);
            userOne = UserCreator.CreateUserOne();
            userTwo = UserCreator.CreateUserTwo();
            incorrectUser = UserCreator.CreateIncorrectUser();
            emailOne = EmailCreator.CreateEmailOne();
            emailTwo = EmailCreator.CreateEmailTwo();
        }
    }
}
