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
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(driver, this);
        }

        protected void SwitchToFrame(string id)
        {
            IWebElement iframe = driver.FindElement(By.Id(id));
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
