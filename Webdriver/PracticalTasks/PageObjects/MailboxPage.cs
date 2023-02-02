using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace PracticalTasks.PageObjects
{
    public class MailboxPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public MailboxPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }
        
        private string composeButtonCss = 
            ".button.button-large.button-solid-norm.w100.no-mobile";
        private string senderOutputXpath =
            "//span[@class='inline-block max-w100 text-ellipsis']";
        private string replyButtonXpath = "//button[.='Reply']";
        private string messageInputIframeXpath =
            "//div[@class='editor-wrapper fill w100 h100 scroll-if-needed flex-item-fluid flex flex-column relative']/iframe[1]";
        private string messageOutputIframeXpath =
            "//iframe[@src='about:blank']";

        private IWebElement ComposeButton => driver.FindElement(By.CssSelector(composeButtonCss));
        private IWebElement ToInput => driver.FindElement(By.CssSelector("[placeholder='Email address']"));
        private IWebElement SubjectInput => driver.FindElement(By.CssSelector("[placeholder='Subject']"));
        private IWebElement MessageInput => driver.FindElement(By.XPath("//div[@id='rooster-editor']"));
        private IWebElement SendButton => driver.FindElement(By.CssSelector(".composer-send-button"));           
        private IWebElement SenderOutput => driver.FindElement(By.XPath(senderOutputXpath));
        private IWebElement MessageContentOutput => driver.FindElement(
            By.CssSelector("#proton-root > div > div > div:nth-of-type(1)"));
        private IWebElement ReplyButton => driver.FindElement(By.XPath(replyButtonXpath));

        public void ComposeEmail(string to, string subject, string body)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(composeButtonCss)));            
            ComposeButton.Click();
            wait.Until(driver => ToInput);
            ToInput.SendKeys(to);
            SubjectInput.SendKeys(subject);
            SwitchToFrame(messageInputIframeXpath);
            MessageInput.Clear();
            MessageInput.SendKeys(body);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            WaitWhileNotVisibleByXpath("//span[.='Message sent.']");
        }

        public string CheckUnreadEmailSenderName()
        {
            WaitWhileNotVisibleByXpath(senderOutputXpath);
            string senderName = SenderOutput.Text;
            return senderName;
        }

        public string ReadRecentEmailGetMessage()
        {
            WaitWhileNotVisibleByXpath(senderOutputXpath);
            SenderOutput.Click();
            WaitWhileNotVisibleByXpath(messageOutputIframeXpath);
            SwitchToFrame(messageOutputIframeXpath);
            string message = MessageContentOutput.Text;
            driver.SwitchTo().DefaultContent();
            return message;
        }

        public void ReplyToEmail(string parsedSubject, string replyMessage)
        {
            string subjectXpath = $"//span[.='{parsedSubject}']";
            WaitWhileNotVisibleByXpath(subjectXpath);
            driver.FindElement(By.XPath(subjectXpath)).Click();
            WaitWhileNotVisibleByXpath(replyButtonXpath);
            ReplyButton.Click();
            WaitWhileNotVisibleByXpath(messageInputIframeXpath);
            SwitchToFrame(messageInputIframeXpath);
            MessageInput.Clear();
            MessageInput.SendKeys(replyMessage);
            driver.SwitchTo().DefaultContent();
            SendButton.Click();
            WaitWhileNotVisibleByXpath("//span[.='Message sent.']");
        }

        private void SwitchToFrame(string frame)
        {
            IWebElement iframe = driver.FindElement(By.XPath(frame));
            wait.Until(driver => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }        

        private void WaitWhileNotVisibleByXpath(string expression)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(expression)));
        }
    }
}
