using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using PracticalTasks.Utils;
using Xunit;

namespace PracticalTasks.Tests
{
    [Collection("LoginTests")]
    public class LoginTests: CommonConditions
    {
        public LoginTests(WebDriverFixture fixture) : base(fixture) { }

        [Fact]
        public void CanLoginWithValidCredentialsTests()
        {           
            loginPage.Login(TestData.Email1, TestData.Password);
            wait.Until(drv => driver.Title.Contains(TestData.Email1));

            Assert.Contains("mail.proton.me", driver.Url);
        }        

        [Fact]
        public void ShouldNotLoginWithIncorrectCredentialsTests()
        {
            IWebElement resultNotification = driver.FindElement(By.
                CssSelector(".notifications-container"));

            loginPage.Login(TestData.Email1, TestData.WrongPassword);  
            wait.Until(drv => resultNotification.Displayed);

            Assert.Equal("Incorrect login credentials. Please try again", resultNotification.Text);
        }

        [Fact]
        public void ShouldNotLoginWithEmptyCredentialsTests()
        {      
            loginPage.Login("", "");

            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("id-3")));
            IWebElement warningNotification = driver.FindElement(By.Id("id-3"));

            Assert.Equal("This field is required", warningNotification.Text);
        }
    }
}
