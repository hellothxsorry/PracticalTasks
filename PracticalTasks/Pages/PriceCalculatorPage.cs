using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Model;

namespace PracticalTasks.Pages
{
    public class PriceCalculatorPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/products/calculator"; } }

        [FindsBy(How = How.CssSelector, Using = "[for='input_92']")]
        private IWebElement? NumberOfInstances;

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

        [FindsBy(How = How.Id, Using = "Email Estimate")]
        private IWebElement? SendTotalCostByEmail;

        public PriceCalculatorPage(IWebDriver driver): base(driver) { }

        public PriceCalculatorPage FillForm(ServerInstance server)
        {
            SwitchToFrame("myFrame");
            NumberOfInstances?.SendKeys(server.NumberOfInstances);
            var selectElement = new SelectElement(OperatingSystemDropdown);
            selectElement.SelectByText(server.OperatingSystem);
            selectElement = new SelectElement(SeriesDropdown);
            selectElement.SelectByText(server.InstanceSeries);
            selectElement = new SelectElement(MachineTypeDropdown);
            selectElement.SelectByText(server.InstanceType);
            AddGpusCheckbox?.Click();
            selectElement = new SelectElement(GpuTypeDropdown);
            selectElement.SelectByText(server.GpuType);
            selectElement = new SelectElement(NumberOfGpusDropdown);
            selectElement.SelectByText(server.NumberOfGpu);
            selectElement = new SelectElement(LocalSsdDropdown);
            selectElement.SelectByText(server.LocalSsd);
            selectElement = new SelectElement(DatacenterLocationDropdown);
            selectElement.SelectByText(server.DatacenterLocation);
            selectElement = new SelectElement(CommittedUsageDropdown);
            selectElement.SelectByText(server.CommittedUsage);
            AddToEstimateButton?.Click();


            return new PriceCalculatorPage(driver);
        }
    }
}
