using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Model;
using PracticalTasks.Utils;

namespace PracticalTasks.Pages
{
    public class PriceCalculatorPage: AbstractPage
    {
        public PriceCalculatorPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public readonly string PageUrl = "https://cloud.google.com/products/calculator";

        private static By NumberOfInstancesInputLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.quantity']");
        private static By OperatingSystemDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.os']");
        private static By SeriesDropdownLocator = By.CssSelector("[name='series']");
        private static By MachineTypeDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.instance']");
        private static By AddGpusCheckboxLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.addGPUs']");
        private static By GpuTypeDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.gpuType']");
        private static By NumberOfGpusDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.gpuCount']");
        private static By LocalSsdDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.ssd']");
        private static By DatacenterLocationDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.location']");
        private static By CommittedUsageDropdownLocator = By.CssSelector("[ng-model='listingCtrl.computeServer.cud']");
        private static By AddToEstimateButtonLocator = By.CssSelector("[ng-click='listingCtrl.addComputeServer(ComputeEngineForm);']");     
        private static By EmailAddressInputLocator = By.CssSelector("[ng-model='emailQuote.user.email']");
        private static By SendEmailButtonLocator = By.CssSelector("[aria-label='Send Email']");
        private static By PricingCalculatorIframeLocator = By.XPath("//iframe[contains(@src,'products/calculator')]");
        private static By TotalEstimatedCostOutputLocator = By.XPath("//div[@class='cpc-cart-total']");
        private static By SendTotalCostByEmailButtonLocator = By.Id("Email Estimate");
        private static By FormIframeLocator = By.Id("myFrame");

        private IWebElement AddGpusCheckbox => driver.FindElement(AddGpusCheckboxLocator);
        private IWebElement TotalEstimatedCostOutput => driver.FindElement(TotalEstimatedCostOutputLocator);
        private IWebElement NumberOfInstancesInput => driver.FindElement(NumberOfInstancesInputLocator);
        private IWebElement EmailAddressInput => driver.FindElement(EmailAddressInputLocator);        
        private IWebElement SendEmailButton => driver.FindElement(SendEmailButtonLocator);
        private IWebElement AddToEstimateButton => driver.FindElement(AddToEstimateButtonLocator);
        private IWebElement SendTotalCostByEmailButton => driver.FindElement(SendTotalCostByEmailButtonLocator);
        private IWebElement OperatingSystemDropdown => driver.FindElement(OperatingSystemDropdownLocator);        
        private IWebElement SeriesDropdown => driver.FindElement(SeriesDropdownLocator);        
        private IWebElement MachineTypeDropdown => driver.FindElement(MachineTypeDropdownLocator);     
        private IWebElement GpuTypeDropdown => driver.FindElement(GpuTypeDropdownLocator);        
        private IWebElement NumberOfGpusDropdown => driver.FindElement(NumberOfGpusDropdownLocator);        
        private IWebElement LocalSsdDropdown => driver.FindElement(LocalSsdDropdownLocator);        
        private IWebElement DatacenterLocationDropdown => driver.FindElement(DatacenterLocationDropdownLocator);
        private IWebElement CommittedUsageDropdown => driver.FindElement(CommittedUsageDropdownLocator);       
              
        public PriceCalculatorPage FillForm(ServerInstance server)
        {
            DriverExtensions.SwitchToFrame(driver, wait, PricingCalculatorIframeLocator);
            DriverExtensions.SwitchToFrame(driver, wait, FormIframeLocator);
            NumberOfInstancesInput.SendKeys(server.NumberOfInstances);
            OperatingSystemDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.OperatingSystem)).Click();
            SeriesDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.InstanceSeries)).Click();
            MachineTypeDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.InstanceType)).Click();
            AddGpusCheckbox.Click();
            GpuTypeDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.GpuType)).Click();
            NumberOfGpusDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.NumberOfGpu)).Click();
            LocalSsdDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.LocalSsd)).Click();
            DatacenterLocationDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.DatacenterLocation));
            Thread.Sleep(50);
            GetItemFromDropdownList(server.DatacenterLocation).Click();
            CommittedUsageDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.CommittedUsage)).Click();
            AddToEstimateButton.Click();
            return new PriceCalculatorPage(driver, wait);
        }        

        public string SelectElementFromDropdownList(ServerInstance server)
        {
            DriverExtensions.SwitchToFrame(driver, wait, PricingCalculatorIframeLocator);
            DriverExtensions.SwitchToFrame(driver, wait, FormIframeLocator);
            wait.Until(drv => OperatingSystemDropdown.Displayed);
            OperatingSystemDropdown.Click();
            wait.Until(drv => GetItemFromDropdownList(server.OperatingSystem)).Click();
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
            DriverExtensions.SwitchToFrame(driver, wait, PricingCalculatorIframeLocator);
            DriverExtensions.SwitchToFrame(driver, wait, FormIframeLocator);
            wait.Until(drv => TotalEstimatedCostOutput);
            string result = TotalEstimatedCostOutput.Text;
            return result;
        }

        private IWebElement GetItemFromDropdownList(string item)
        {
            IWebElement element = driver.FindElement(By.XPath($"//md-option[contains(.,'{item}')]"));
            return element;
        }
    }
}