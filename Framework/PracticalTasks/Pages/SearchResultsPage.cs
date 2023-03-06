using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Utils;

namespace PracticalTasks.Pages
{
    public class SearchResultsPage: AbstractPage
    {
        private static By SearchResultLinkLocator = By.CssSelector("[data-ctorig='https://cloud.google.com/products/calculator']");

        public IWebElement SearchResultLink => driver.FindElement(SearchResultLinkLocator);

        public SearchResultsPage(IWebDriver driver, WebDriverWait wait): base(driver, wait) { }

        public void GoToSearchResultPage()
        {
            WaitingUtil.WaitUntilVisible(wait, SearchResultLinkLocator);
            SearchResultLink.Click();
        }

        public string GetFirstSearchResult()
        {
            WaitingUtil.WaitUntilVisible(wait, SearchResultLinkLocator);
            string result = SearchResultLink.Text;
            return result;
        }
    }
}
