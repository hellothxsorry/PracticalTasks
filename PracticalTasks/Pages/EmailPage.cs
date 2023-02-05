using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PracticalTasks.Pages
{
    public class EmailPage: AbstractPage
    {
        protected override string PageUrl { get { return "https://yopmail.com/"; } }

        [FindsBy(How = How.CssSelector, Using = "[title='Disposable Email Address Generator creates a new fake email for you in one click! Freely use this anounymous email on Internet']")]
        private IWebElement? RandomEmailGeneratorButton;

        [FindsBy(How = How.Id, Using = "cprnd")]
        private IWebElement? CopyEmailToClipboardButton;

        [FindsBy(How = How.XPath, Using = "//button[.='Check Inbox']")]
        private IWebElement? CheckInboxButton;

        [FindsBy(How = How.Id, Using = "refresh")]
        private IWebElement? RefreshInboxButton;

        public EmailPage(IWebDriver driver): base(driver) { }

        public EmailPage GenerateEmail()
        {
            wait.Until(drv => RandomEmailGeneratorButton?.Displayed);
            RandomEmailGeneratorButton?.Click();
            return this;
        }

        public EmailPage CopyGeneratedEmail()
        {
            wait.Until(drv => CopyEmailToClipboardButton?.Displayed);
            CopyEmailToClipboardButton?.Click();
            return this;
        }

        public EmailPage CheckInbox()
        {
            wait.Until(drv => CheckInboxButton?.Displayed);
            CheckInboxButton?.Click();
            return this;
        }

        public EmailPage RefreshInbox()
        {
            wait.Until(drv => RefreshInboxButton?.Displayed);
            RefreshInboxButton?.Click();
            return this;
        }

        public EmailPage ReadMostRecentEmail()
        {

            return this;
        }
    }
}
