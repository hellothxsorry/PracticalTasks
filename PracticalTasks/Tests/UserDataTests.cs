using Xunit;
using PracticalTasks.Utils;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace PracticalTasks.Tests
{
    public class UserDataTests: IClassFixture<WebDriverFixture>
    {
        private WebDriverFixture fixture;

        public UserDataTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CanChangeUsername()
        {
            fixture.LoginPage.Login(TestData.Email2, TestData.Password);
            fixture.ProfilePage.ChangeName(TestData.NewNickname1);

            string result = fixture.ProfilePage.GetCurrentName();

            Assert.Equal(TestData.NewNickname1, result);
        }

        [Fact]
        public void CanSendReplyChangeName()
        {
            string incomingMailParsedSubject =
                $"//span[.='{TestData.Subject1}']";

            fixture.LoginPage.Login(TestData.Email1, TestData.Password);
            fixture.MailboxPage.ComposeEmail(TestData.Email2, TestData.Subject1, TestData.EmailBodyContent);
            fixture.ProfilePage.SignOut();

            fixture.LoginPage.Login(TestData.Email2, TestData.Password);
            fixture.MailboxPage.ReplyToEmail(TestData.Subject1, TestData.NewNickname1);
            fixture.ProfilePage.SignOut();

            fixture.LoginPage.Login(TestData.Email1, TestData.Password);
            fixture.Wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath(incomingMailParsedSubject)));
            string newName = fixture.MailboxPage.ReadRecentEmailGetMessage();
            fixture.ProfilePage.ChangeName(newName);
            string result = fixture.ProfilePage.GetCurrentName();

            Assert.Equal(TestData.NewNickname1, result);
        }
    }
}
