using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.Pages
{
    public class SearchResultsPage: AbstractPage
    {
        private static By SearchResultLinkLocator = By.CssSelector("[data-ctorig='https://cloud.google.com/products/calculator']");

        public IWebElement SearchResultLink => driver.FindElement(SearchResultLinkLocator);

        public SearchResultsPage(IWebDriver driver, WebDriverWait wait): base(driver, wait) { }

        public void GoToSearchResultPage()
        {
            wait.Until(drv => SearchResultLink.Displayed);
            SearchResultLink.Click();
        }

        public string GetFirstSearchResult()
        {
            wait.Until(drv => SearchResultLink.Displayed);
            string result = SearchResultLink.Text;
            return result;
        }
    }
}
