using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PracticalTasks.Utils
{
    public static class DriverExtensions
    {
        public static void SwitchToFrame(WebDriverWait wait, IWebDriver driver, By locator)
        {
            var iframe = driver.FindElement(locator);
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }
    }
}
