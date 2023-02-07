using PracticalTasks.TestSteps;
using OpenQA.Selenium;
using Xunit;
using PracticalTasks.Model;
using PracticalTasks.Services;
using PracticalTasks.Pages;
using Xunit.Abstractions;
using System.Reflection;

namespace PracticalTasks.Tests
{
    public class SmokeTests: CommonConditions
    {
        [Fact]
        public void CanOpenResearchResults()
        {
            steps.InitializeBrowser();
            steps.OpenCalculatorPageBySearchRequest();
            steps.OpenNewBrowserTab();

            string result = steps.CheckResultsAfterSearch();

            Assert.Equal(TestDataReader.GetTestData("testdata.searchRequest"),
                result);
        }

        [Fact]
        public void CanGenerateTempEmailAddress()
        {
            steps.InitializeBrowser();
            string result = steps.GenerateTempEmail();

            Assert.Contains("@yopmail.com", result);
        }

        [Fact]
        public void CanSelectElementFromDropdownList()
        {
            steps.InitializeBrowser();
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(steps.Driver);
            priceCalculatorPage.OpenPage();
            string result = priceCalculatorPage.SelectElementFromDropdownList(server);

            Assert.Contains(TestDataReader.GetTestData("testdata.server.operatingSystemW"), result);
        }
    }
}
