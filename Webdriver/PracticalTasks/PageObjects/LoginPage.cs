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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            driver.Navigate().GoToUrl("https://account.proton.me/login");
        }

        private IWebElement UserEmailInput => driver.FindElement(By.XPath("//input[@id='username']"));
        private IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement SubmitButton => driver.FindElement(
            By.XPath("//button[@class='button w100 button-large button-solid-norm mt1-5']"));

        public void Login(string email, string password)
        {
            wait.Until(drv => UserEmailInput.Displayed);
            UserEmailInput.SendKeys(email);
            PasswordInput.SendKeys(password);
            SubmitButton.Click();
        }
    }    
}
