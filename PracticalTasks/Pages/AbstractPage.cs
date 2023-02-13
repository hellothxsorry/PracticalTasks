using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected abstract string PageUrl { get; }

        protected AbstractPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }

        protected void SwitchToFrame(By locator)
        {
            var iframe = driver.FindElement(locator);
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
