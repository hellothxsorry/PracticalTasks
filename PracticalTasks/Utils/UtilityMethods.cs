using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticalTasks.Utils
{
    public static class UtilityMethods
    {
        public static void SwitchToFrame(WebDriverWait wait, IWebDriver driver, By locator)
        {
            var iframe = driver.FindElement(locator);
            wait.Until(drv => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }

        public static void WaitUntilVisible(WebDriverWait wait, By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}