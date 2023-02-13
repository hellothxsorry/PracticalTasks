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
        private static By MessageOutputLocator = By.XPath("//div[@id='proton-root']/descendant::div[contains(@style,'font-family')]");
        private static By SendButtonLocator = By.CssSelector("[data-testid='composer:send-button']");
        private static By ReplyButtonLocator = By.CssSelector("[data-testid='message-view:reply']");
        private static By NewMessageButtonLocator = By.CssSelector("[data-testid='sidebar:compose']");
        private static By ToInputLocator = By.CssSelector("[data-testid='composer:to']");
        private static By SubjectInputLocator = By.CssSelector("[data-testid='composer:subject']");        
        private static By IframeMessageInputLocator = By.CssSelector("[data-testid=rooster-iframe]");
        private static By IframeMessageOutputLocator = By.CssSelector("[data-testid=content-iframe]");
        private static By RefreshInboxButtonLocator = By.CssSelector("[data-testid='navigation-link:refresh-folder']");
        private static By SuccessfulNotificationOutputLocator = By.XPath("//span[.='Message sent.']");        
        private static By SenderEmailAddressOutputLocator = By.XPath("(//span[@data-testid='message-column:sender-address'])[1]");
        
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
            UtilityMethods.WaitUntilVisible(wait, NewMessageButtonLocator);            
            NewMessageButton.Click();
            wait.Until(driver => ToInput);
            ToInput.SendKeys(to);
            SubjectInput.SendKeys(subject);
            UtilityMethods.SwitchToFrame(wait, driver, IframeMessageInputLocator);
            MessageInput.Clear();
            MessageInput.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(SuccessfulNotificationOutputLocator));
        }

        public string CheckUnreadEmailSenderAddress()
        {
            UtilityMethods.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            string senderEmailAddress = SenderEmailAddressOutput.GetAttribute("title");
            return senderEmailAddress;
        }

        public string ReadRecentEmailGetMessage()
        {
            Thread.Sleep(2000);
            UtilityMethods.WaitUntilVisible(wait, RefreshInboxButtonLocator);
            RefreshInboxButton.Click();
            UtilityMethods.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            SenderEmailAddressOutput.Click();
            UtilityMethods.WaitUntilVisible(wait, IframeMessageOutputLocator);
            UtilityMethods.SwitchToFrame(wait, driver, IframeMessageOutputLocator);
            UtilityMethods.WaitUntilVisible(wait, MessageOutputLocator);
            string message = MessageContentOutput.Text;
            driver.SwitchTo().DefaultContent();
            return message;
        }

        public void ReplyToEmail(string sender, string replyMessage)
        {
            UtilityMethods.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            Thread.Sleep(2000);
            RefreshInboxButton.Click();
            UtilityMethods.WaitUntilVisible(wait, SenderEmailAddressOutputLocator);
            SenderEmailAddressOutput.Click();
            UtilityMethods.WaitUntilVisible(wait, ReplyButtonLocator);
            ReplyButton.Click();
            UtilityMethods.WaitUntilVisible(wait, IframeMessageInputLocator);
            UtilityMethods.SwitchToFrame(wait, driver, IframeMessageInputLocator);
            UtilityMethods.WaitUntilVisible(wait, MessageInputLocator);
            MessageInput.Clear();
            MessageInput.SendKeys(replyMessage);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            UtilityMethods.WaitUntilVisible(wait, SuccessfulNotificationOutputLocator);
        }        
    }
}