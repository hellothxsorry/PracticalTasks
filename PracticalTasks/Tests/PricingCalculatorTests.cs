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
        [Trait("Category", "Task")]
        public void ShouldCheckEstimatedMonthlyCostTests()
        {            
            Steps.OpenCalculatorPageBySearchRequest(driver);
            Steps.FillCalculatorForm(driver);
            Steps.OpenNewBrowserTab(driver);
            string tempEmail = Steps.GenerateTempEmail(driver);
            Steps.SwitchBackToLastBrowserTab(driver, 0);
            string estimatedCostFromCalculator = Steps.GetEstimatedCostFromCalculator(driver);
            Steps.SendReportToGeneratedMail(driver, tempEmail);
            Steps.SwitchBackToLastBrowserTab(driver, 1);
            string estimatedCostFromEmail = Steps.GetEstimatedCostFromEmail(driver);

            Assert.Contains(estimatedCostFromEmail, estimatedCostFromCalculator);

            Steps.DisposeTest(driver);
        }
    }
}
