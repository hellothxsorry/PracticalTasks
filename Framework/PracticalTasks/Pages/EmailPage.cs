using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Utils;

namespace PracticalTasks.Pages
{
    public class EmailPage: AbstractPage
    {
        public EmailPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        public readonly string PageUrl = "https://yopmail.com/";

        private static By InboxIframeLocator = By.Id("ifinbox");
        private static By MessageBodyIframeLocator = By.Id("ifmail");
        private static By GenerateEmailOutputLocator = By.Id("geny");
        private static By CheckInboxButtonLocator = By.XPath("//button[contains(@onClick,'egengo')]/child::span[not(@*)]");
        private static By RefreshInboxButtonLocator = By.Id("refresh");
        private static By FirstEmailButtonLocator = By.XPath("//body[contains(@class,'bodyinbox')]/descendant::button[@class='lm']");
        private static By RandomEmailGeneratorButtonLocator = By.XPath("//div[@id='listeliens']/child::a[contains(@href,'generator')]");
        private static By EstimatedCostOutputLocator = By.XPath("//td[contains(text(),'USD')]");        

        public IWebElement RandomEmailGeneratorButton => driver.FindElement(RandomEmailGeneratorButtonLocator);        
        public IWebElement CheckInboxButton => driver.FindElement(CheckInboxButtonLocator);
        public IWebElement RefreshInboxButton => driver.FindElement(RefreshInboxButtonLocator);
        public IWebElement FirstEmailButton => driver.FindElement(FirstEmailButtonLocator);        
        public IWebElement EstimatedCostOutput => driver.FindElement(EstimatedCostOutputLocator);
        public IWebElement GeneratedEmailOutput => driver.FindElement(GenerateEmailOutputLocator);
        public IWebElement InboxIframe => driver.FindElement(InboxIframeLocator);
        public IWebElement MessageBodyIframe => driver.FindElement(MessageBodyIframeLocator);        

        public EmailPage GenerateEmail()
        {
            WaitingUtil.WaitUntilVisible(wait, RandomEmailGeneratorButtonLocator);
            RandomEmailGeneratorButton.Click();
            return this;
        }

        public string CopyGeneratedEmail()
        {
            WaitingUtil.WaitUntilVisible(wait, GenerateEmailOutputLocator);
            string result = GeneratedEmailOutput.Text;
            return result;
        }

        public EmailPage CheckInbox()
        {
            WaitingUtil.WaitUntilVisible(wait, CheckInboxButtonLocator);
            CheckInboxButton.Click();
            return this;
        }

        public EmailPage RefreshInbox()
        {
            WaitingUtil.WaitUntilVisible(wait, RefreshInboxButtonLocator);
            Thread.Sleep(1500);
            RefreshInboxButton.Click();
            return this;
        }

        public EmailPage ReadMostRecentEmail()
        {
            DriverExtensions.SwitchToFrame(driver, wait, InboxIframeLocator);
            WaitingUtil.WaitUntilVisible(wait, FirstEmailButtonLocator);
            FirstEmailButton.Click();
            driver.SwitchTo().DefaultContent();
            return this;
        }

        public string ParseCostFromEmailContent()
        {
            DriverExtensions.SwitchToFrame(driver, wait, MessageBodyIframeLocator);
            WaitingUtil.WaitUntilVisible(wait, EstimatedCostOutputLocator);
            string result = EstimatedCostOutput.Text;
            driver.SwitchTo().DefaultContent();
            return result;
        }
    }
}
