using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Utils;

namespace PracticalTasks.PageObjects
{
    public class ProfilePage: AbstractPage
    {
        public ProfilePage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private static By NewNameInputLocator = By.Id("displayName");
        private static By GearButtonLocator = By.CssSelector("[data-test-id='view:general-settings']");
        private static By AccountButtonLocator = By.CssSelector("[title='Account and password']");
        private static By SignOutButtonLocator = By.CssSelector("[data-testid='userdropdown:button:logout']");
        private static By SignInButtonLocator = By.CssSelector("[type='submit']");
        private static By DisplayedNameLabelLocator = By.CssSelector("[data-testid='heading:userdropdown']");
        private static By GoToSettingsButtonLocator = By.XPath("//a[.='Go to settings']");        
        private static By EditButtonLocator = By.XPath("//button[contains(text(),'Edit')]");
        private static By SaveButtonLocator = By.XPath("//button[contains(text(),'Save')]");        
        private static By NewNameSuccessNotificationOutputLocator = By.XPath("//div[contains(text(),'Display name updated')]");
        
        public IWebElement GearButton => driver.FindElement(GearButtonLocator);     
        public IWebElement GoToSettingsButton => driver.FindElement(GoToSettingsButtonLocator);
        public IWebElement AccountButton => driver.FindElement(AccountButtonLocator);
        public IWebElement EditButton => driver.FindElement(EditButtonLocator);
        public IWebElement SaveButton => driver.FindElement(SaveButtonLocator);
        public IWebElement SignOutButton => driver.FindElement(SignOutButtonLocator);
        public IWebElement DisplayedNameLabel => driver.FindElement(DisplayedNameLabelLocator);
        public IWebElement NewNameInput => driver.FindElement(NewNameInputLocator);        

        public void ChangeName(string newName)
        {
            UtilityMethods.WaitUntilVisible(wait, GearButtonLocator);
            GearButton.Click();
            UtilityMethods.WaitUntilVisible(wait, GoToSettingsButtonLocator);
            GoToSettingsButton.Click();
            UtilityMethods.WaitUntilVisible(wait, AccountButtonLocator);
            AccountButton.Click();
            UtilityMethods.WaitUntilVisible(wait, EditButtonLocator);
            EditButton.Click();
            UtilityMethods.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            NewNameInput.SendKeys(newName);
            SaveButton.Click();
            UtilityMethods.WaitUntilVisible(wait, NewNameSuccessNotificationOutputLocator);
        }

        public string GetCurrentName()
        {
            UtilityMethods.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            var parsedName = DisplayedNameLabel.GetAttribute("title");
            int index = parsedName.IndexOf("<");            
            var currentName = parsedName.Substring(0, index).Trim();
            return currentName;
        }

        public void SignOut()
        {
            UtilityMethods.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            DisplayedNameLabel.Click();
            UtilityMethods.WaitUntilVisible(wait, SignOutButtonLocator);
            SignOutButton.Click();
            UtilityMethods.WaitUntilVisible(wait, SignInButtonLocator);
        }
    }
}