using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticalTasks.Utils
{
    public static class WaitingUtils
    {
        public static void WaitUntilVisible(WebDriverWait wait, By locator)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
    }
}
