using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Utils;

namespace PracticalTasks.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;        

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://www.mail.com");
        }

        private IWebElement txtUserEmail => driver.FindElement(By.Id("login-email"));
        private IWebElement txtPassword => driver.FindElement(By.Id("login-password"));
        private IWebElement btnLogin => driver.FindElement(By.Id("login-button"));
        private IWebElement btnSubmit => driver.FindElement(By.CssSelector("button.login-submit"));

        public void Login(string email, string password)
        {
            wait.Until(drv => btnLogin);
            btnLogin.Click();
            txtUserEmail.SendKeys(email);
            txtPassword.SendKeys(password);
            btnSubmit.Click();
        }
    }    
}
