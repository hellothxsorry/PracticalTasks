using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using PracticalTasks.PageObjects;
using PracticalTasks.Utils;

namespace PracticalTasks.Tests
{
    public class EmailTests: IClassFixture<WebDriverFixture>
    {
        private WebDriverFixture fixture;

        public EmailTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CanSendMail()
        {
            fixture.LoginPage.Login(TestData.Email1, TestData.Password1);
            fixture.MailboxPage.ComposeEmail(TestData.Email2, TestData.Subject1, TestData.EmailBodyContent);
        }

        [Fact]
        public void CanReadMail()
        {

        }

        [Fact]
        public void CanCheckUnreadMail()
        {

        }        
    }
}
