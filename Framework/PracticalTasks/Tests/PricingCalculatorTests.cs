using PracticalTasks.Driver;
using PracticalTasks.TestSteps;
using Xunit;

namespace PracticalTasks.Tests
{
    [Collection("PricingCalculatorTests")]
    public class PricingCalculatorTests: CommonConditions
    {
        public PricingCalculatorTests(WebDriverFixture webDriverFixture) : base(webDriverFixture) { }

        [Fact]
        [Trait("Category", "AllTests")]
        public void ShouldCheckEstimatedMonthlyCostTests()
        {            
            Steps.OpenCalculatorPageBySearchRequest(driver, wait);
            Steps.FillCalculatorForm(driver, wait);
            Steps.OpenNewBrowserTab(driver);
            string tempEmail = Steps.GenerateTempEmail(driver, wait);
            Steps.SwitchBackToLastBrowserTab(driver, 0);
            string estimatedCostFromCalculator = Steps.GetEstimatedCostFromCalculator(driver, wait);
            Steps.SendReportToGeneratedMail(driver, wait, tempEmail);
            Steps.SwitchBackToLastBrowserTab(driver, 1);
            string estimatedCostFromEmail = Steps.GetEstimatedCostFromEmail(driver, wait);

            Assert.Contains(estimatedCostFromEmail, estimatedCostFromCalculator);
        }
    }
}
