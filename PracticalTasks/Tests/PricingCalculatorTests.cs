using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Driver;
using PracticalTasks.Model;
using Xunit;

namespace PracticalTasks.Tests
{
    public class PricingCalculatorTests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public void SetUp()
        {
            driver = WebDriverManager.GetInstance();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        [Fact]
        public void CanCheckEstimatedMonthlyCost()
        {
            ServerInstance testServer;
        }
    }
}
