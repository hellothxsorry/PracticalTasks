﻿using OpenQA.Selenium;
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
        private static By NewNameSuccessNotificationOutputLocator = By.CssSelector("[role='alert']");
        private static By GoToSettingsButtonLocator = By.XPath("//li[@class='dropdown-item']/child::a");        
        private static By EditButtonLocator = By.XPath("//section[@id='account']/descendant::button[contains(@class,'link')]");
        private static By SaveButtonLocator = By.XPath("//button[@type='submit']");       
        
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
            WaitingUtils.WaitUntilVisible(wait, GearButtonLocator);
            GearButton.Click();
            WaitingUtils.WaitUntilVisible(wait, GoToSettingsButtonLocator);
            GoToSettingsButton.Click();
            WaitingUtils.WaitUntilVisible(wait, AccountButtonLocator);
            AccountButton.Click();
            WaitingUtils.WaitUntilVisible(wait, EditButtonLocator);
            EditButton.Click();
            WaitingUtils.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            NewNameInput.SendKeys(newName);
            SaveButton.Click();
            WaitingUtils.WaitUntilVisible(wait, NewNameSuccessNotificationOutputLocator);
        }

        public string GetCurrentName()
        {
            WaitingUtils.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            var parsedName = DisplayedNameLabel.GetAttribute("title");
            int index = parsedName.IndexOf("<");            
            var currentName = parsedName.Substring(0, index).Trim();
            return currentName;
        }

        public void SignOut()
        {
            WaitingUtils.WaitUntilVisible(wait, DisplayedNameLabelLocator);
            DisplayedNameLabel.Click();
            WaitingUtils.WaitUntilVisible(wait, SignOutButtonLocator);
            SignOutButton.Click();
            WaitingUtils.WaitUntilVisible(wait, SignInButtonLocator);
        }
    }
}