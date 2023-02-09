using Xunit;
using OpenQA.Selenium;
using PracticalTasks.Utils;

namespace PracticalTasks.Tests
{
    [Collection("EmailTests")]
    public class EmailTests: CommonConditions
    {
        public EmailTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void CanSendMailTests()
        {          
            loginPage.Login(TestData.Email1, TestData.Password);
            mailboxPage.ComposeEmail(TestData.Email2, TestData.Subject1, TestData.EmailBodyContent);

            IWebElement successNotification = driver.FindElement(By.
                XPath("//span[.='Message sent.']"));

            Assert.Equal("Message sent.", successNotification.Text);
        }

        [Fact]
        public void CanVerifyUnreadMailTests()
        {
            loginPage.Login(TestData.Email2, TestData.Password);

            Assert.Equal(TestData.Username1, mailboxPage.CheckUnreadEmailSenderName());
        }

        [Fact]
        public void CanReadMailTests()
        {
            loginPage.Login(TestData.Email2, TestData.Password);

            Assert.Contains(TestData.EmailBodyContent, mailboxPage.ReadRecentEmailGetMessage());
        }           
    }
}
