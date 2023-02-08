using OpenQA.Selenium;
using PracticalTasks.Driver;
using PracticalTasks.TestSteps;
using System.Reflection;
using Xunit;

namespace PracticalTasks.Tests
{
    public class PricingCalculatorTests
    {
        private IWebDriver driver;

        [Fact]
        public void CanCheckEstimatedMonthlyCost()
        {
            Steps steps = new Steps();
            driver = WebDriverManager.GetInstance();
            steps.OpenCalculatorPageBySearchRequest(driver);
            steps.FillCalculatorForm(driver);
            steps.OpenNewBrowserTab(driver);
            string tempEmail = steps.GenerateTempEmail(driver);
            steps.SwitchBackToLastBrowserTab(driver, 0);
            string estimatedCostFromCalculator = steps.GetEstimatedCostFromCalculator(driver);
            steps.SendReportToGeneratedMail(driver, tempEmail);
            steps.SwitchBackToLastBrowserTab(driver, 1);
            string estimatedCostFromEmail = steps.GetEstimatedCostFromEmail(driver);

            Assert.Contains(estimatedCostFromEmail, estimatedCostFromCalculator);

            steps.DisposeTest(driver);
        }
    }
}
