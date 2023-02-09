using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using PracticalTasks.Model;

namespace PracticalTasks.Pages
{
    public class PriceCalculatorPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://cloud.google.com/products/calculator"; } }

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.quantity']")]
        private IWebElement NumberOfInstancesInput;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.os']")]
        private IWebElement OperatingSystemDropdown;

        [FindsBy(How = How.XPath, Using = "//md-select[@name='series']")]
        private IWebElement SeriesDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.instance']")]
        private IWebElement MachineTypeDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.addGPUs']")]
        private IWebElement AddGpusCheckbox;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.gpuType']")]
        private IWebElement GpuTypeDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.gpuCount']")]
        private IWebElement NumberOfGpusDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.ssd']")]
        private IWebElement LocalSsdDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.location']")]
        private IWebElement DatacenterLocationDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='listingCtrl.computeServer.cud']")]
        private IWebElement CommittedUsageDropdown;

        [FindsBy(How = How.CssSelector, Using = "[ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']")]
        private IWebElement AddToEstimateButton;

        [FindsBy(How = How.XPath, Using =
            "//div[@class='cpc-cart-total']//b[contains(text(), 'USD')]")]
        private IWebElement TotalEstimatedCostOutput;

        [FindsBy(How = How.Id, Using = "Email Estimate")]
        private IWebElement SendTotalCostByEmailButton;

        [FindsBy(How = How.XPath, Using =
            "//iframe[@src='https://cloud.google.com/frame/products/calculator/index_d6a98ba38837346d20babc06ff2153b68c2990fa24322fe52c5f83ec3a78c6a0.frame']")]
        private IWebElement PricingCalculatorIframe;

        [FindsBy(How = How.Id, Using = "myFrame")]
        private IWebElement FormIframe;

        [FindsBy(How = How.CssSelector, Using = "[ng-model='emailQuote.user.email']")]
        private IWebElement EmailAddressInput;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Send Email')]")]
        private IWebElement SendEmailButton;

        public PriceCalculatorPage(IWebDriver driver): base(driver) { }

        public PriceCalculatorPage FillForm(ServerInstance server)
        {
            SwitchToFrame(PricingCalculatorIframe);
            SwitchToFrame(FormIframe);
            NumberOfInstancesInput.SendKeys(server.NumberOfInstances);
            OperatingSystemDropdown.Click();
            wait.Until(drv => GetElementFromDropdownList(server.OperatingSystem)).Click();
            SeriesDropdown.Click();
            wait.Until(drv => GetElementFromDropdownList(server.InstanceSeries)).Click();
            MachineTypeDropdown.Click();
            wait.Until(drv => GetMachineTypeFromDropdownList(server.InstanceType)).Click();
            AddGpusCheckbox.Click();
            GpuTypeDropdown.Click();
            wait.Until(drv => GetElementFromDropdownList(server.GpuType)).Click();
            NumberOfGpusDropdown.Click();
            wait.Until(drv => GetGpuNumberFromDropdownList(server.NumberOfGpu)).Click();
            LocalSsdDropdown.Click();
            wait.Until(drv => GetElementFromDropdownList(server.LocalSsd)).Click();
            DatacenterLocationDropdown.Click();
            wait.Until(drv => GetLocationFromDropdownList(server.DatacenterLocation));
            Thread.Sleep(50);
            GetLocationFromDropdownList(server.DatacenterLocation).Click();
            CommittedUsageDropdown.Click();
            wait.Until(drv => GetCommittedUsageFromDropdownList(server.CommittedUsage)).Click();
            AddToEstimateButton.Click();
            return new PriceCalculatorPage(driver);
        }        

        public string SelectElementFromDropdownList(ServerInstance server)
        {
            SwitchToFrame(PricingCalculatorIframe);
            SwitchToFrame(FormIframe);
            wait.Until(drv => OperatingSystemDropdown.Displayed);
            OperatingSystemDropdown.Click();
            wait.Until(drv => GetElementFromDropdownList(server.OperatingSystem)).Click();
            string result = OperatingSystemDropdown.Text;
            return result;
        }

        public PriceCalculatorPage SendEstimatedCostByEmail(string email)
        {
            wait.Until(drv => SendTotalCostByEmailButton.Displayed);
            SendTotalCostByEmailButton.Click();
            wait.Until(drv => EmailAddressInput.Displayed);
            EmailAddressInput.SendKeys(email);
            SendEmailButton.Click();
            return this;
        }

        public string GetEstimatedCost()
        {
            SwitchToFrame(PricingCalculatorIframe);
            SwitchToFrame(FormIframe);
            wait.Until(drv => TotalEstimatedCostOutput);
            string result = TotalEstimatedCostOutput.Text;
            return result;
        }

        private IWebElement GetElementFromDropdownList(string option)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//md-option[contains(.,'{option}')]"));
            return element;
        }

        private IWebElement GetMachineTypeFromDropdownList(string option)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//md-optgroup[3]//div[contains(.,'{option}')]"));
            return element;
        }

        private IWebElement GetLocationFromDropdownList(string option)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//div[@class='md-select-menu-container cpc-region-select md-active md-clickable']//md-option[contains(.,'{option}')]"));
            return element;
        }

        private IWebElement GetGpuNumberFromDropdownList(string option)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//div[@class='md-select-menu-container md-active md-clickable']//md-option[contains(.,'{option}')]"));
            return element;
        }

        private IWebElement GetCommittedUsageFromDropdownList(string option)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//div[@class='md-select-menu-container md-active md-clickable']//md-option[.='{option}']"));
            return element;
        }
    }
}