using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.PageObjects
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected AbstractPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
        }             
    }
}