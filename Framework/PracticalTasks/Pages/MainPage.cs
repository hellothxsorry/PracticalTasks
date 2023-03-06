using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Utils;

namespace PracticalTasks.Pages
{
    public class MainPage: AbstractPage
    {
        public MainPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public readonly string PageUrl = "https://cloud.google.com/";

        private static By SearchInputLocator = By.Name("q");
        
        public IWebElement SearchInput => driver.FindElement(SearchInputLocator);         

        public SearchResultsPage StartSearchFor(string request)
        {
            WaitingUtil.WaitUntilVisible(wait, SearchInputLocator);
            SearchInput.SendKeys(request);
            SearchInput.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver, wait);
        }
    }
}
