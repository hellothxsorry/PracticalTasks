﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected abstract string PageUrl { get; }

        protected AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            PageFactory.InitElements(driver, this);
        }

        protected void SwitchToFrame(IWebElement iframe)
        {            
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public void OpenNewBrowserTab()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public void SwitchToPreviousTab()
        {

        }
    }
}
