using PracticalTasks.TestSteps;
using Xunit;
using PracticalTasks.Model;
using PracticalTasks.Services;
using PracticalTasks.Pages;
using PracticalTasks.Driver;
using PracticalTasks.Utils;

namespace PracticalTasks.Tests
{
    [Collection("SequentialTestCollection")]
    public class SmokeTests: CommonConditions
    {
        public SmokeTests(WebDriverFixture webDriverFixture) : base(webDriverFixture) { }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "AllTests")]
        public void ShouldOpenResearchResultsTests()
        {            
            Steps.OpenCalculatorPageBySearchRequest(driver, wait);
            Steps.OpenNewBrowserTab(driver);

            var result = Steps.CheckResultsAfterSearch(driver, wait);

            Assert.Contains(result, TestDataReader.GetTestData("testdata.searchRequest"));
        }

        [Fact]
        [Trait("Category", "Smoke")]
        [Trait("Category", "AllTests")]
        public void ShouldGenerateTempEmailAddressTests()
        {
            string result = Steps.GenerateTempEmail(driver, wait);

            Assert.Contains("@yopmail.com", result);
        }

        [Fact]
        [Trait("Category", "AllTests")]
        public void ShouldSelectElementFromDropdownListTests()
        {
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver, wait);
            DriverExtensions.OpenPage(driver, priceCalculatorPage.PageUrl);
            string result = priceCalculatorPage.SelectElementFromDropdownList(server);

            Assert.Contains(TestDataReader.GetTestData("testdata.server.operatingSystem"), result);
        }
    }
}
