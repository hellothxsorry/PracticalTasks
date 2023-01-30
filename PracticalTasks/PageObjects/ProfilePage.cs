using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.PageObjects
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement MyAccountButton => driver.FindElement(By.
            XPath("//li[@class='item']/" +
            "a[@class='iac account' and @title='My Account' and text()='My Account']"));
        private IWebElement PersonalDataButton => driver.FindElement(By.
            XPath("//div[@class='nav-item folder preset active']/" +
            "a[@class='label active' and .//span[@class='text' and text()='Personal Data']]"));
        private IWebElement EditProfileButton => driver.FindElement(By.
            XPath("//div[@class='links-menu__link-header']/" +
            "div[@class='links-menu__link-header-title' and text()='Profile']"));
        private IWebElement FirstNameInput => driver.FindElement(By.
            XPath("//div[@class='pos-input']/input[@type='text']"));
        private IWebElement PasswordInput => driver.FindElement(By.
            XPath("//input[@id='2:editBirthDataPanel:form:passwordPanel:" +
            "topWrapper:inputWrapper:input' and @type='password']"));
        private IWebElement SaveButton => driver.FindElement(By.
            Id("//button[@id='id1d']"));

        public void ChangeUsername(string newFirstName, string confirmingPassword)
        {
            wait.Until(drv => MyAccountButton);
            MyAccountButton.Click();
            wait.Until(drv => PersonalDataButton);
            PersonalDataButton.Click();
            wait.Until(drv => EditProfileButton);
            EditProfileButton.Click();
            wait.Until(drv => FirstNameInput);
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(newFirstName);
            PasswordInput.SendKeys(confirmingPassword);
            SaveButton.Click();
        }
    }
}
