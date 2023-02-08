using PracticalTasks.TestSteps;
using OpenQA.Selenium;
using Xunit;
using PracticalTasks.Model;
using PracticalTasks.Services;
using PracticalTasks.Pages;
using PracticalTasks.Driver;

namespace PracticalTasks.Tests
{
    public class SmokeTests
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void CanOpenResearchResults()
        {
            IWebDriver driver = WebDriverManager.GetInstance();
            Steps steps = new Steps();
            steps.OpenCalculatorPageBySearchRequest(driver);
            steps.OpenNewBrowserTab(driver);

            string result = steps.CheckResultsAfterSearch(driver);

            Assert.Contains(result, TestDataReader.GetTestData("testdata.searchRequest"));

            steps.DisposeTest(driver);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void CanGenerateTempEmailAddress()
        {
            IWebDriver driver = WebDriverManager.GetInstance();
            Steps steps = new Steps();
            string result = steps.GenerateTempEmail(driver);

            Assert.Contains("@yopmail.com", result);

            steps.DisposeTest(driver);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void CanSelectElementFromDropdownList()
        {
            IWebDriver driver = WebDriverManager.GetInstance();
            Steps steps = new Steps();
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.OpenPage();
            string result = priceCalculatorPage.SelectElementFromDropdownList(server);

            Assert.Contains(TestDataReader.GetTestData("testdata.server.operatingSystem"), result);

            steps.DisposeTest(driver);
        }
    }
}
