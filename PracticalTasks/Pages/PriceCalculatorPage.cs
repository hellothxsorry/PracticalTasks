using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public class PriceCalculatorPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/products/calculator"; } }

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? OperatingSystemDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? SeriesDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? MachineTypeDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? AddGpusCheckbox;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? GpuTypeDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? NumberOfGpusDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? LocalSsdDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? DatacenterLocationDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? CommittedUsageDropdown;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? AddToEstimateButton;

        [FindsBy(How = How.Name, Using = "q")]
        private IWebElement? TotalEstimatedCostOutput;

        public PriceCalculatorPage(IWebDriver driver): base(driver) { }

    }
}
