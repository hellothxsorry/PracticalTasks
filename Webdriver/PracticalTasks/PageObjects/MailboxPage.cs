using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using PracticalTasks.Utils;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.PageObjects
{
    public class MailboxPage: AbstractPage
    {
        public MailboxPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private static By MessageInputLocator = By.Id("rooster-editor");
        private static By MessageOutputLocator = By.XPath("//div[@id='proton-root']/descendant::div//div//div");
        private static By SendButtonLocator = By.CssSelector("[data-testid='composer:send-button']");
        private static By ReplyButtonLocator = By.CssSelector("[data-testid='message-view:reply']");
        private static By NewMessageButtonLocator = By.CssSelector("[data-testid='sidebar:compose']");
        private static By ToInputLocator = By.CssSelector("[data-testid='composer:to']");
        private static By SubjectInputLocator = By.CssSelector("[data-testid='composer:subject']");        
        private static By IframeMessageInputLocator = By.CssSelector("[data-testid=rooster-iframe]");
        private static By IframeMessageOutputLocator = By.CssSelector("[data-testid=content-iframe]");
        private static By RefreshInboxButtonLocator = By.CssSelector("[data-testid='navigation-link:refresh-folder']");
        private static By SuccessfulNotificationOutputLocator = By.CssSelector("[role='alert']");        
        private static By SenderEmailAddressOutputLocator = By.XPath("//span[@data-testid='message-column:sender-address']");
        
        public IWebElement NewMessageButton => driver.FindElement(NewMessageButtonLocator);
        public IWebElement ReplyButton => driver.FindElement(ReplyButtonLocator);
        public IWebElement SendButton => driver.FindElement(SendButtonLocator);
        public IWebElement RefreshInboxButton => driver.FindElement(RefreshInboxButtonLocator);
        public IWebElement ToInput => driver.FindElement(ToInputLocator);
        public IWebElement SubjectInput => driver.FindElement(SubjectInputLocator);
        public IWebElement MessageInput => driver.FindElement(MessageInputLocator);                 
        public IWebElement SenderEmailAddressOutput => driver.FindElement(SenderEmailAddressOutputLocator);
        public IWebElement MessageContentOutput => driver.FindElement(MessageOutputLocator);        
        public IWebElement SuccessNotificationOutput => driver.FindElement(SuccessfulNotificationOutputLocator);

        public void ComposeEmail(string to, string subject, string body)
        {
            WaitingUtil.WaitUntilVisible(wait, NewMessageButtonLocator);            
            NewMessageButton.Click();
            wait.Until(driver => ToInput);
            ToInput.SendKeys(to);
            SubjectInput.SendKeys(subject);
            DriverExtensions.SwitchToFrame(wait, driver, IframeMessageInputLocator);
            MessageInput.Clear();
            MessageInput.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(SuccessfulNotificationOutputLocator));
        }

        public string CheckUnreadEmailSenderAddress()
        {
            WaitingUtil.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            string senderEmailAddress = SenderEmailAddressOutput.GetAttribute("title");
            return senderEmailAddress;
        }

        public string ReadRecentEmailGetMessage()
        {
            Thread.Sleep(2000);
            WaitingUtil.WaitUntilVisible(wait, RefreshInboxButtonLocator);
            RefreshInboxButton.Click();
            WaitingUtil.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            SenderEmailAddressOutput.Click();
            WaitingUtil.WaitUntilVisible(wait, IframeMessageOutputLocator);
            DriverExtensions.SwitchToFrame(wait, driver, IframeMessageOutputLocator);
            WaitingUtil.WaitUntilVisible(wait, MessageOutputLocator);
            string message = MessageContentOutput.Text;
            driver.SwitchTo().DefaultContent();
            return message;
        }

        public void ReplyToEmail(string replyMessage)
        {
            WaitingUtil.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            Thread.Sleep(2000);
            RefreshInboxButton.Click();
            WaitingUtil.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            SenderEmailAddressOutput.Click();
            WaitingUtil.WaitUntilVisible(wait, ReplyButtonLocator);
            ReplyButton.Click();
            WaitingUtil.WaitUntilVisible(wait, IframeMessageInputLocator);
            DriverExtensions.SwitchToFrame(wait, driver, IframeMessageInputLocator);
            WaitingUtil.WaitUntilVisible(wait, MessageInputLocator);
            MessageInput.Clear();
            MessageInput.SendKeys(replyMessage);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            WaitingUtil.WaitUntilVisible(wait, SuccessfulNotificationOutputLocator);
        }        
    }
}