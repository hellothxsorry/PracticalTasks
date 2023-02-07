using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Driver;
using PracticalTasks.Model;
using PracticalTasks.Services;
using PracticalTasks.TestSteps;
using Xunit;

namespace PracticalTasks.Tests
{
    public class PricingCalculatorTests: CommonConditions
    {

        [Fact]
        public void CanCheckEstimatedMonthlyCost()
        {
            steps.InitializeBrowser();
            steps.OpenCalculatorPageBySearchRequest();
            steps.FillCalculatorForm();
            steps.OpenNewBrowserTab();
            string tempEmail = steps.GenerateTempEmail();
            steps.SwitchBackToLastBrowserTab(0);
            string estimatedCostFromCalculator = steps.GetEstimatedCostFromCalculator();
            steps.SendReportToGeneratedMail(tempEmail);
            steps.SwitchBackToLastBrowserTab(1);
            string estimatedCostFromEmail = steps.GetEstimatedCostFromEmail();

            Assert.Contains(estimatedCostFromEmail, estimatedCostFromCalculator);
        }
    }
}
