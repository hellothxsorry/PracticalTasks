using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PracticalTasks.PageObjects
{
    public class MailboxPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public MailboxPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement ComposeButton => driver.FindElement(By.
            CssSelector("a.iac.mail_compose[data-iac-usecase='mail_compose']"));
        private IWebElement ToInput => driver.FindElement(By.
            CssSelector("[data-webdriver='to'] input.select2-input"));
        private IWebElement SubjectInput => driver.FindElement(By.ClassName("mailobjectpanel-textfield_input"));
        private IWebElement MessageInput => driver.FindElement(By.CssSelector(".cke_editable.cke_editable_themed.cke_contents_ltr"));
        private IWebElement SendButton => driver.FindElement(By.Id("compose-send-button"));
        private IWebElement MailTabButton => driver.FindElement(By.CssSelector("a[data-item-name='mail'][data-nav='menu-item']"));
        private IWebElement InboxButton => driver.FindElement(By.XPath("//span[text()='Inbox']/.."));
        private IWebElement SentButton => driver.FindElement(By.XPath("//span[text()='Sent']/.."));

        public void ComposeEmail(string to, string subject, string body)
        {
            SwitchToFrame("//iframe[@id='thirdPartyFrame_home']");
            wait.Until(driver => ComposeButton);            
            ComposeButton.Click();
            driver.SwitchTo().DefaultContent();
            SwitchToFrame("//iframe[@id='thirdPartyFrame_mail']");
            wait.Until(driver => ToInput);
            ToInput.SendKeys(to);
            SubjectInput.SendKeys(subject);
            SwitchToFrame("//iframe[@class='cke_wysiwyg_frame cke_reset']");
            MessageInput.SendKeys(body);
            driver.SwitchTo().ParentFrame();
            SendButton.Click();
            driver.SwitchTo().DefaultContent();
        }

        public void CheckUnreadEmail(string from)
        {

        }

        public void ReadEmail()
        {

        }

        public void Logout()
        {

        }

        private void SwitchToFrame(string frame)
        {
            IWebElement iframe = driver.FindElement(By.XPath(frame));
            wait.Until(driver => iframe.Displayed);
            driver.SwitchTo().Frame(iframe);
        }
    }
}
