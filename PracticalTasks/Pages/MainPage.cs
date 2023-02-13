using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PracticalTasks.Pages
{
    public class MainPage: AbstractPage
    {
        public MainPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        protected override string PageUrl { get { return "https://cloud.google.com/"; } }

        private static By SearchInputLocator = By.Name("q");
        
        public IWebElement SearchInput => driver.FindElement(SearchInputLocator);         

        public SearchResultsPage StartSearchFor(string request)
        {
            wait.Until(drv => SearchInput.Displayed);
            SearchInput?.SendKeys(request);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
