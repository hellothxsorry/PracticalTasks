using Xunit;
using PracticalTasks.Driver;

namespace PracticalTasks.Tests
{
    public class LoginTests: CommonConditions
    {
        public LoginTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void LoginWithValidCredentialsTest()
        {           
            loginPage.Login(userOne.EmailAddress, userOne.Password);
            wait.Until(drv => driver.Title.Contains(userOne.EmailAddress));

            Assert.Contains(userOne.EmailAddress, driver.Title);

            profilePage.SignOut();
        }        

        [Fact]
        public void LoginWithIncorrectCredentialsTest()
        {
            loginPage.Login(incorrectUser.EmailAddress, incorrectUser.Password);  
            wait.Until(drv => loginPage.VerificationLoginOutput);

            Assert.Contains("Human Verification", loginPage.VerificationLoginOutput.Text);
        }

        [Fact]
        public void LoginWithEmptyCredentialsTest()
        {      
            loginPage.Login("", "");
            wait.Until(drv => loginPage.EmptyCredentialsOutput);

            Assert.Contains("This field is required", loginPage.EmptyCredentialsOutput.Text);
        }
    }
}
