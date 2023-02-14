using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Services;
using PracticalTasks.Utils;

namespace PracticalTasks.PageObjects
{
    public class LoginPage: AbstractPage
   {
        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) 
        {
            driver.Navigate().GoToUrl(pageUrl);
        }

        private static By EmailAddressInputLocator = By.Id("username");
        private static By PasswordInputLocator = By.Id("password");
        private static By SignInButtonLocator = By.CssSelector("[type='submit']");
        private static By VerificationLoginOutputLocator = By.CssSelector("[data-testid='verification']");
        private static By IncorrectCredentialsOutputLocator = By.CssSelector("[role='alert']");
        private static By EmptyCredentialsOutputLocator = By.XPath("//*[name()='svg']/following-sibling::span[not(@*)]");

        public IWebElement SignInButton => driver.FindElement(SignInButtonLocator);
        public IWebElement EmailAddressInput => driver.FindElement(EmailAddressInputLocator);
        public IWebElement PasswordInput => driver.FindElement(PasswordInputLocator);
        public IWebElement IncorrectCredentialsOutput => driver.FindElement(IncorrectCredentialsOutputLocator);
        public IWebElement EmptyCredentialsOutput => driver.FindElement(EmptyCredentialsOutputLocator);
        public IWebElement VerificationLoginOutput => driver.FindElement(VerificationLoginOutputLocator);

        private readonly string pageUrl = TestDataReader.GetTestData("page.url");

        public void Login(string email, string password)
        {
            WaitingUtil.WaitUntilVisible(wait, EmailAddressInputLocator);
            EmailAddressInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SignInButton.Click();
        }
    }    
}