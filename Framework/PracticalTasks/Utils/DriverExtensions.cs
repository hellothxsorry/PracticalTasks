using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.Utils
{
    public static class DriverExtensions
    {
        public static void SwitchToFrame(IWebDriver driver, WebDriverWait wait, By locator)
        {
            var iframe = driver.FindElement(locator);
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }

        public static void OpenPage(IWebDriver driver, string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
