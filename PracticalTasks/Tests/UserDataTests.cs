using Xunit;
using PracticalTasks.Utils;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium;

namespace PracticalTasks.Tests
{
    [Collection("UserDataTests")]
    public class UserDataTests: CommonConditions
    {
        public UserDataTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void CanChangeUsernameTests()
        {
            loginPage.Login(TestData.Email2, TestData.Password);
            profilePage.ChangeName(TestData.NewNickname1);

            Assert.Equal(TestData.NewNickname1, profilePage.GetCurrentName());
        }

        [Fact]
        public void CanSendReplyChangeNameTests()
        {
            var incomingMailParsedSubject =
                $"//span[.='{TestData.Subject1}']";

            loginPage.Login(TestData.Email1, TestData.Password);
            mailboxPage.ComposeEmail(TestData.Email2, TestData.Subject1, TestData.EmailBodyContent);
            profilePage.SignOut();

            loginPage.Login(TestData.Email2, TestData.Password);
            mailboxPage.ReplyToEmail(TestData.Subject1, TestData.NewNickname1);
            profilePage.SignOut();

            loginPage.Login(TestData.Email1, TestData.Password);
            wait.Until(ExpectedConditions.ElementIsVisible(
                By.XPath(incomingMailParsedSubject)));
            string newName = mailboxPage.ReadRecentEmailGetMessage();
            profilePage.ChangeName(newName);

            Assert.Equal(TestData.NewNickname1, profilePage.GetCurrentName());
        }
    }
}
