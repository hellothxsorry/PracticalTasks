using PracticalTasks.TestSteps;
using Xunit;
using PracticalTasks.Model;
using PracticalTasks.Services;
using PracticalTasks.Pages;
using PracticalTasks.Driver;

namespace PracticalTasks.Tests
{
    [Collection("SequentialTestCollection")]
    public class SmokeTests: CommonConditions
    {
        public SmokeTests(WebDriverFixture webDriverFixture) : base(webDriverFixture) { }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ShouldOpenResearchResultsTests()
        {            
            Steps.OpenCalculatorPageBySearchRequest(driver);
            Steps.OpenNewBrowserTab(driver);

            var result = Steps.CheckResultsAfterSearch(driver);

            Assert.Contains(result, TestDataReader.GetTestData("testdata.searchRequest"));

            Steps.DisposeTest(driver);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ShouldGenerateTempEmailAddressTests()
        {
            string result = Steps.GenerateTempEmail(driver);

            Assert.Contains("@yopmail.com", result);

            Steps.DisposeTest(driver);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ShouldSelectElementFromDropdownListTests()
        {
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.OpenPage();
            string result = priceCalculatorPage.SelectElementFromDropdownList(server);

            Assert.Contains(TestDataReader.GetTestData("testdata.server.operatingSystem"), result);

            Steps.DisposeTest(driver);
        }
    }
}
