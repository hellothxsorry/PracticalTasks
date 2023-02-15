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
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.OperatingSystem));
            ChooseItemFromDropdownList(server.OperatingSystem);
            SeriesDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.InstanceSeries));
            ChooseItemFromDropdownList(server.InstanceSeries);
            MachineTypeDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.InstanceType));
            ChooseItemFromDropdownList(server.InstanceType);
            AddGpusCheckbox.Click();
            GpuTypeDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.GpuType));
            ChooseItemFromDropdownList(server.GpuType);
            NumberOfGpusDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetGpuNumberLocatorFromDropdownList(server.NumberOfGpu));
            ChooseGpuNumberFromDropdownList(server.NumberOfGpu);
            LocalSsdDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.LocalSsd));
            ChooseItemFromDropdownList(server.LocalSsd);
            DatacenterLocationDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetLocationLocatorFromDropdownList(server.DatacenterLocation));
            ChooseLocationFromDropdownList(server.DatacenterLocation);
            CommittedUsageDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetCommittedUsageLocatorFromDropdownList(server.CommittedUsage));
            ChooseCommittedUsageFromDropdownList(server.CommittedUsage);
            AddToEstimateButton.Click();
            return new PriceCalculatorPage(driver, wait);
        }        

        public string SelectElementFromDropdownList(ServerInstance server)
        {
            DriverExtensions.SwitchToFrame(driver, wait, PricingCalculatorIframeLocator);
            DriverExtensions.SwitchToFrame(driver, wait, FormIframeLocator);
            WaitingUtil.WaitUntilVisible(wait, OperatingSystemDropdownLocator);
            OperatingSystemDropdown.Click();
            WaitingUtil.WaitUntilVisible(wait, GetItemLocatorFromDropdownList(server.OperatingSystem));

            string result = OperatingSystemDropdown.Text;
            return result;
        }

        public PriceCalculatorPage SendEstimatedCostByEmail(string email)
        {
            WaitingUtil.WaitUntilVisible(wait, SendTotalCostByEmailButtonLocator);
            SendTotalCostByEmailButton.Click();
            WaitingUtil.WaitUntilVisible(wait, EmailAddressInputLocator);
            EmailAddressInput.SendKeys(email);
            SendEmailButton.Click();
            return this;
        }

        public string GetEstimatedCost()
        {
            DriverExtensions.SwitchToFrame(driver, wait, PricingCalculatorIframeLocator);
            DriverExtensions.SwitchToFrame(driver, wait, FormIframeLocator);
            WaitingUtil.WaitUntilVisible(wait, TotalEstimatedCostOutputLocator);
            string result = TotalEstimatedCostOutput.Text;
            return result;
        }

        private By GetItemLocatorFromDropdownList(string item)
        {
            var itemLocator = By.XPath($"//md-option[contains(.,'{item}')]");
            return itemLocator;
        }

        private void ChooseItemFromDropdownList(string item)
        {
            var itemElement = driver.FindElement(By.XPath($"//md-option[contains(.,'{item}')]"));
            itemElement.Click();
        }

        private By GetGpuNumberLocatorFromDropdownList(string item)
        {
            var itemLocator = By.XPath($"//md-option[contains(.,'{item}') and contains(@ng-repeat,'gpuType')]");
            return itemLocator;
        }

        private void ChooseGpuNumberFromDropdownList(string item)
        {
            var itemElement = driver.FindElement(By.XPath($"//md-option[contains(.,'{item}') and contains(@ng-repeat,'gpuType')]"));
            itemElement.Click();
        }               

        private By GetLocationLocatorFromDropdownList(string item)
        {
            var locator = By.XPath(
                $"//div[contains(@class,'cpc-region-select')]/descendant::md-option[contains(.,'{item}') and contains(@ng-repeat,'computeServer')]");
            return locator;
        }

        private void ChooseLocationFromDropdownList(string item)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//div[contains(@class,'cpc-region-select')]/descendant::md-option[contains(.,'{item}') and contains(@ng-repeat,'computeServer')]"));
            element.Click();
        }        

        private By GetCommittedUsageLocatorFromDropdownList(string item)
        {
            var locator = By.XPath($"//div[contains(@class,'md-active')]/descendant::md-option[.='{item}']");
            return locator;
        }

        private void ChooseCommittedUsageFromDropdownList(string item)
        {
            IWebElement element = driver.FindElement(
                By.XPath($"//div[contains(@class,'md-active')]/descendant::md-option[.='{item}']"));
            element.Click();
        }
    }
}