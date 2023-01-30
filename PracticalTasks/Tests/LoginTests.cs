using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PracticalTasks.PageObjects;
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
            fixture.LoginPage.Login(TestData.Email1, TestData.Password1);

            Assert.True(fixture.Driver.Title.Contains("Free Email Addresses: Web based and secure Email - mail.com"), 
                "mail.com - your personal Email and News");
        }        

        [Fact]
        public void ShouldNotLoginWithIncorrectCredentials()
        {
            fixture.LoginPage.Login(TestData.Email1, TestData.WrongPassword);

            IWebElement errorMessage = fixture.Driver.FindElement(By.CssSelector("div.text-wrapper h1"));
            Assert.Equal("PLEASE TRY AGAIN!", errorMessage.Text);
        }

        [Fact]
        public void ShouldNotLoginWithEmptyCredentials()
        {
            fixture.LoginPage.Login("", "");

            IWebElement errorMessage = fixture.Driver.FindElement(By.CssSelector("div.text-wrapper h1"));
            Assert.Equal("PLEASE TRY AGAIN!", errorMessage.Text);
        }
    }
}
