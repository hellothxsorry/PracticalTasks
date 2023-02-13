using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.Pages
{
    public class EmailPage: AbstractPage
    {
        public EmailPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        protected override string PageUrl { get { return "https://yopmail.com/"; } }

        private static By InboxIframeLocator = By.Id("ifinbox");
        private static By MessageBodyIframeLocator = By.Id("ifmail");
        private static By GenerateEmailOutputLocator = By.Id("geny");
        private static By CheckInboxButtonLocator = By.Id("refreshbut");
        private static By RefreshInboxButtonLocator = By.Id("refresh");
        private static By FirstEmailButtonLocator = By.XPath("(//body[contains(@class,'bodyinbox')]/descendant::button[@class='lm'])[1]");
        private static By RandomEmailGeneratorButtonLocator = By.XPath("//div[@id='listeliens']/child::a[contains(@href,'generator')]");
        private static By EstimatedCostOutputLocator = By.XPath("//td[contains(text(),'USD')]");        

        public IWebElement RandomEmailGeneratorButton => driver.FindElement(RandomEmailGeneratorButtonLocator);
        public IWebElement GeneratedEmailOutput => driver.FindElement(GenerateEmailOutputLocator);
        public IWebElement CheckInboxButton => driver.FindElement(CheckInboxButtonLocator);
        public IWebElement RefreshInboxButton => driver.FindElement(RefreshInboxButtonLocator);
        public IWebElement FirstEmailButton => driver.FindElement(FirstEmailButtonLocator);        
        public IWebElement EstimatedCostOutput => driver.FindElement(EstimatedCostOutputLocator);        
        public IWebElement InboxIframe => driver.FindElement(InboxIframeLocator);
        public IWebElement MessageBodyIframe => driver.FindElement(MessageBodyIframeLocator);        

        public EmailPage GenerateEmail()
        {
            wait.Until(drv => RandomEmailGeneratorButton.Displayed);
            RandomEmailGeneratorButton.Click();
            return this;
        }

        public string CopyGeneratedEmail()
        {
            wait.Until(drv => GeneratedEmailOutput.Displayed);
            string result = GeneratedEmailOutput.Text;
            return result;
        }

        public EmailPage CheckInbox()
        {
            wait.Until(drv => CheckInboxButton.Displayed);
            CheckInboxButton.Click();
            return this;
        }

        public EmailPage RefreshInbox()
        {
            wait.Until(drv => RefreshInboxButton.Displayed);
            Thread.Sleep(1500);
            RefreshInboxButton.Click();
            return this;
        }

        public EmailPage ReadMostRecentEmail()
        {
            SwitchToFrame(InboxIframeLocator);
            wait.Until(drv => FirstEmailButton.Displayed);
            FirstEmailButton.Click();
            driver.SwitchTo().DefaultContent();
            return this;
        }

        public string ParseCostFromEmailContent()
        {
            SwitchToFrame(MessageBodyIframeLocator);
            wait.Until(drv => EstimatedCostOutput.Displayed);
            string result = EstimatedCostOutput.Text;
            driver.SwitchTo().DefaultContent();
            return result;
        }
    }
}
