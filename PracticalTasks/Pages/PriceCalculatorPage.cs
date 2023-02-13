using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Model;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public class PriceCalculatorPage: AbstractPage
    {
        public PriceCalculatorPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        protected override string PageUrl { get { return "https://cloud.google.com/products/calculator"; } }

        private static By PricingCalculatorIframeLocator = By.XPath("//iframe[contains(@src,'products/calculator')]");
        private static By FormIframeLocator = By.Id("myFrame");

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
                
        private IWebElement PricingCalculatorIframe => driver.FindElement(PricingCalculatorIframeLocator);

        private IWebElement FormIframe => driver.FindElement(FormIframeLocator);

        [FindsBy(How = How.CssSelector, Using = "[ng-model='emailQuote.user.email']")]
        private IWebElement EmailAddressInput;

        [FindsBy(How = How.XPath, Using = "//button[contains(.,'Send Email')]")]
        private IWebElement SendEmailButton;        

        public PriceCalculatorPage FillForm(ServerInstance server)
        {
            SwitchToFrame(PricingCalculatorIframeLocator);
            SwitchToFrame(FormIframeLocator);
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
            return new PriceCalculatorPage(driver, wait);
        }        

        public string SelectElementFromDropdownList(ServerInstance server)
        {
            SwitchToFrame(PricingCalculatorIframeLocator);
            SwitchToFrame(FormIframeLocator);
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
            SwitchToFrame(PricingCalculatorIframeLocator);
            SwitchToFrame(FormIframeLocator);
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