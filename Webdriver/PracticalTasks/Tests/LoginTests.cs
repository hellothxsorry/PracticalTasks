using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using PracticalTasks.Utils;
using Xunit;

namespace PracticalTasks.Tests
{
    public class LoginTests: IClassFixture<WebDriverFixture>
    {
        private WebDriverFixture fixture;

        public LoginTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CanLoginWithValidCredentials()
        {           
            fixture.LoginPage.Login(TestData.Email1, TestData.Password);
            fixture.Wait.Until(drv => fixture.Driver.Title.Contains(TestData.Email1));

            Assert.Contains("mail.proton.me", fixture.Driver.Url);
        }        

        [Fact]
        public void ShouldNotLoginWithIncorrectCredentials()
        {
            IWebElement resultNotification = fixture.Driver.FindElement(By.
                CssSelector(".notifications-container"));

            fixture.LoginPage.Login(TestData.Email1, TestData.WrongPassword);  
            fixture.Wait.Until(drv => resultNotification.Displayed);

            Assert.Equal("Incorrect login credentials. Please try again", resultNotification.Text);
        }

        [Fact]
        public void ShouldNotLoginWithEmptyCredentials()
        {      
            fixture.LoginPage.Login("", "");

            fixture.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("id-3")));
            IWebElement warningNotification = fixture.Driver.FindElement(By.Id("id-3"));

            Assert.Equal("This field is required", warningNotification.Text);
        }
    }
}
