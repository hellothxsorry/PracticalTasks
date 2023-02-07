using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace PracticalTasks.Pages
{
    public class MainPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/"; } }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement SearchInput;     
        
        public MainPage(IWebDriver driver): base(driver) { }

        public SearchResultsPage StartSearchFor(string request)
        {
            wait.Until(drv => SearchInput.Displayed);
            SearchInput?.SendKeys(request);
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
