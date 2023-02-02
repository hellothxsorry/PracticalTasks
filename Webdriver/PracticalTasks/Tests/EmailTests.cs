using Xunit;
using OpenQA.Selenium;
using PracticalTasks.Utils;
using SeleniumExtras.WaitHelpers;

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
            fixture.LoginPage.Login(TestData.Email1, TestData.Password);
            fixture.MailboxPage.ComposeEmail(TestData.Email2, TestData.Subject1, TestData.EmailBodyContent);
            
            IWebElement successNotification = fixture.Driver.FindElement(By.
                XPath("//span[.='Message sent.']"));

            Assert.Equal("Message sent.", successNotification.Text);
        }

        [Fact]
        public void CanVerifyUnreadMail()
        {
            fixture.LoginPage.Login(TestData.Email2, TestData.Password);
            string result = fixture.MailboxPage.CheckUnreadEmailSenderName();

            Assert.Equal(TestData.Username1, result);
        }

        [Fact]
        public void CanReadMail()
        {
            fixture.LoginPage.Login(TestData.Email2, TestData.Password);
            string result = fixture.MailboxPage.ReadRecentEmailGetMessage();

            Assert.Contains(TestData.EmailBodyContent, result);
        }           
    }
}
