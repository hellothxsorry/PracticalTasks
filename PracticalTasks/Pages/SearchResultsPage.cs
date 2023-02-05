using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public class SearchResultsPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/s/results?hl=en&q=google%20cloud%20pricing%20calculator&text=Google%20Cloud%20Pricing%20Calculator"; } }

        [FindsBy(How = How.XPath, Using = "//div[@class='gsc-expansionArea']//div[@class='gsc-thumbnail-inside']/div[.='Google Cloud Pricing Calculator']")]
        private IWebElement? SearchResultLink;

        public SearchResultsPage(IWebDriver driver): base(driver) { }

        public PriceCalculatorPage GoToSearchResultPage()
        {
            wait.Until(drv => SearchResultLink?.Displayed);
            return new PriceCalculatorPage(driver);
        }
    }
}
