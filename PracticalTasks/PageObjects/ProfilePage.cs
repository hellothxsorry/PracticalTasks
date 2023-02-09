using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticalTasks.PageObjects
{
    public class ProfilePage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public ProfilePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        private string gearButtonXpath = "//span[.='Settings']";
        private string accountButtonXpath = "//a[.='Account and password']";
        private string goToSettingsButtonXpath = "//a[.='Go to settings']";
        private string displayedNameCss = ".user-dropdown-displayName";
        private string signOutButtonXpath = 
            "//button[@class='button button-solid-norm w100']";
        private string newNameSuccessNotificationXpath = 
            "//div[@class='p1 mb0-5 text-break notification notification--in bg-success']";

        private IWebElement GearButton => driver.FindElement(By.XPath(gearButtonXpath));        
        private IWebElement GoToSettingsButton => driver.FindElement(By.XPath(goToSettingsButtonXpath));
        private IWebElement AccountButton => driver.FindElement(By.XPath(accountButtonXpath));
        private IWebElement EditButton => driver.FindElement(By.CssSelector(".link"));
        private IWebElement DisplayedName => driver.FindElement(By.CssSelector(displayedNameCss));
        private IWebElement NewNameInput => driver.FindElement(By.Id("displayName"));
        private IWebElement SaveButton => driver.FindElement(By.CssSelector(".button-solid-norm"));
        private IWebElement SignOutButton => driver.FindElement(By.XPath(signOutButtonXpath));

        public void ChangeName(string newName)
        {
            WaitWhileNotVisibleByXpath(gearButtonXpath);
            GearButton.Click();
            WaitWhileNotVisibleByXpath(goToSettingsButtonXpath);
            GoToSettingsButton.Click();
            WaitWhileNotVisibleByXpath(accountButtonXpath);
            AccountButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".link")));
            EditButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("displayName")));
            NewNameInput.SendKeys(newName);
            SaveButton.Click();
            WaitWhileNotVisibleByXpath(newNameSuccessNotificationXpath);
        }

        public string GetCurrentName()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(displayedNameCss)));
            string currentName = DisplayedName.Text;
            return currentName;
        }

        public void SignOut()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(displayedNameCss)));
            DisplayedName.Click();
            WaitWhileNotVisibleByXpath(signOutButtonXpath);
            SignOutButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".button-large")));
        }

        private void WaitWhileNotVisibleByXpath(string expression)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(expression)));
        }
    }
}
