using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public class EmailPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://yopmail.com/"; } }

        [FindsBy(How = How.CssSelector, Using = "[title='Disposable Email Address Generator creates a new fake email for you in one click! Freely use this anounymous email on Internet']")]
        private IWebElement RandomEmailGeneratorButton;

        [FindsBy(How = How.Id, Using = "geny")]
        private IWebElement GeneratedEmailOutput;

        [FindsBy(How = How.XPath, Using = "//button[.='Check Inbox']")]
        private IWebElement CheckInboxButton;

        [FindsBy(How = How.Id, Using = "refresh")]
        private IWebElement RefreshInboxButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='mctn']/div[2]/button[@class='lm']")]
        private IWebElement FirstEmailButton;

        [FindsBy(How = How.XPath, Using = "//td[4]")]
        private IWebElement EstimatedCostOutput;

        [FindsBy(How = How.Id, Using = "ifinbox")]
        private IWebElement InboxIframe;

        [FindsBy(How = How.Id, Using = "ifmail")]
        private IWebElement MessageBodyIframe;

        public EmailPage(IWebDriver driver): base(driver) { }

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
            Thread.Sleep(550);
            RefreshInboxButton.Click();
            return this;
        }

        public EmailPage ReadMostRecentEmail()
        {
            SwitchToFrame(InboxIframe);
            wait.Until(drv => FirstEmailButton.Displayed);
            FirstEmailButton.Click();
            driver.SwitchTo().DefaultContent();
            return this;
        }

        public string ParseCostFromEmailContent()
        {
            SwitchToFrame(MessageBodyIframe);
            wait.Until(drv => EstimatedCostOutput.Displayed);
            string result = EstimatedCostOutput.Text;
            driver.SwitchTo().DefaultContent();
            return result;
        }
    }
}
