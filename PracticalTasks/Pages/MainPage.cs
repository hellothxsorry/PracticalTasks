using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;


namespace PracticalTasks.Pages
{
    public class MainPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/"; } }

        [FindsBy(How = How.CssSelector, Using = "[search-open]")]
        private IWebElement? SearchButton;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? SearchInput;     
        
        public MainPage(IWebDriver driver): base(driver) { }

        public SearchResultsPage StartSearchFor()
        {
            wait.Until(drv => SearchButton?.Displayed);
            SearchButton?.Click();
            wait.Until(drv => SearchInput?.Displayed);
            SearchInput?.SendKeys("asd");
            SearchInput?.SendKeys(Keys.Enter);
            return new SearchResultsPage(driver);
        }
    }
}
