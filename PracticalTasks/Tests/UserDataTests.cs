using Xunit;
using PracticalTasks.Driver;

namespace PracticalTasks.Tests
{
    public class UserDataTests: CommonConditions
    {
        public UserDataTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void ChangeUsernameTest()
        {
            loginPage.Login(userTwo.EmailAddress, userTwo.Password);
            profilePage.ChangeName(emailTwo.Message);

            Assert.Equal(emailTwo.Message, profilePage.GetCurrentName());
        }

        [Fact]
        public void SendReplyToChangeNameTest()
        {
            loginPage.Login(userOne.EmailAddress, userOne.Password);
            mailboxPage.ComposeEmail(userTwo.EmailAddress, emailOne.Subject, emailOne.Message);
            profilePage.SignOut();

            loginPage.Login(userTwo.EmailAddress, userTwo.Password);
            mailboxPage.ReplyToEmail(userOne.EmailAddress, emailTwo.Message);
            profilePage.SignOut();

            loginPage.Login(userOne.EmailAddress, userOne.Password);            
            var newName = mailboxPage.ReadRecentEmailGetMessage();
            profilePage.ChangeName(newName);

            Assert.Equal(emailTwo.Message, profilePage.GetCurrentName());
        }
    }
}
