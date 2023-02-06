using PracticalTasks.TestSteps;
using OpenQA.Selenium;
using Xunit;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Model;
using PracticalTasks.Services;
using Xunit.Abstractions;

namespace PracticalTasks.Tests
{
    public class SmokeTests: IDisposable
    {
        private Steps steps = new Steps();

        [Fact]
        public void CanPutValueIntoTextField()
        {
            ServerInstance server = ServerCreator.WithSetupFromProperty();            
            steps.InitializeBrowser();
            steps.Driver.Navigate().GoToUrl("https://cloud.google.com/products/calculator");
            WebDriverWait wait = new WebDriverWait(steps.Driver, TimeSpan.FromSeconds(10));
            IWebElement iframe = steps.Driver.FindElement(By.XPath("//iframe[@src='https://cloud.google.com/frame/products/calculator/index_d6a98ba38837346d20babc06ff2153b68c2990fa24322fe52c5f83ec3a78c6a0.frame']"));
            wait.Until(drv => iframe.Displayed);
            steps.Driver.SwitchTo().Frame(iframe);
            iframe = steps.Driver.FindElement(By.Id("myFrame"));
            steps.Driver.SwitchTo().Frame(iframe);
            IWebElement numberOfInstances = steps.Driver.FindElement(By.CssSelector("[ng-model='listingCtrl.computeServer.quantity']"));
            numberOfInstances.SendKeys(server.NumberOfInstances);
            string result = numberOfInstances.Text;
            Assert.Equal("4", result);
        }

        public void Dispose()
        {
            steps.Driver.Quit();
            steps.Driver.Dispose();
        }
    }
}
