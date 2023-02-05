using OpenQA.Selenium;
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

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
    }
}
