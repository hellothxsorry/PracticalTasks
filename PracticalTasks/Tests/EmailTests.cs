using Xunit;
using PracticalTasks.Driver;

namespace PracticalTasks.Tests
{
    public class EmailTests: CommonConditions
    {
        public EmailTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void SendMailTest()
        {
            loginPage.Login(userOne.EmailAddress, userOne.Password);
            mailboxPage.ComposeEmail(userTwo.EmailAddress, emailOne.Subject, emailOne.Message);

            Assert.Equal("Message sent.", mailboxPage.SuccessNotificationOutput.Text);
        }

        [Fact]
        public void VerifyUnreadMailTest()
        {
            loginPage.Login(userTwo.EmailAddress, userTwo.Password);

            Assert.Equal(userOne.EmailAddress, mailboxPage.CheckUnreadEmailSenderAddress());
        }

        [Fact]
        public void ReadMailTest()
        {
            loginPage.Login(userTwo.EmailAddress, userTwo.Password);

            Assert.Contains(emailOne.Message, mailboxPage.ReadRecentEmailGetMessage());
        }           
    }
}