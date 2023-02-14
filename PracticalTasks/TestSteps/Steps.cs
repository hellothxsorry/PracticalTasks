using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Model;
using PracticalTasks.Pages;
using PracticalTasks.Services;
using PracticalTasks.Utils;
using System.Reflection;

namespace PracticalTasks.TestSteps
{
    public class Steps
    {
        public void OpenCalculatorPageBySearchRequest(IWebDriver driver, WebDriverWait wait)
        {
            MainPage mainPage = new MainPage(driver, wait);
            DriverExtensions.OpenPage(driver, mainPage.PageUrl);
            mainPage.StartSearchFor(TestDataReader.GetTestData("testdata.searchRequest"));
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver, wait);
            searchResultsPage.GoToSearchResultPage();
        }

        public string CheckResultsAfterSearch(IWebDriver driver, WebDriverWait wait)
        {
            MainPage mainPage = new MainPage(driver, wait);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver, wait);
            DriverExtensions.OpenPage(driver, mainPage.PageUrl);
            mainPage.StartSearchFor(TestDataReader.GetTestData("testdata.searchRequest"));
            string result = searchResultsPage.GetFirstSearchResult();
            return result;
        }

        public void FillCalculatorForm(IWebDriver driver, WebDriverWait wait)
        {
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver, wait);
            priceCalculatorPage.FillForm(server);
        }

        public void OpenNewBrowserTab(IWebDriver driver)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public string GenerateTempEmail(IWebDriver driver, WebDriverWait wait)
        {
            EmailPage emailPage = new EmailPage(driver, wait);
            DriverExtensions.OpenPage(driver, emailPage.PageUrl);
            string result = emailPage.GenerateEmail()
                .CopyGeneratedEmail();
            return result;
        }

        public void SwitchBackToLastBrowserTab(IWebDriver driver, int tabNumber)
        {
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[tabNumber]);
        }

        public void SendReportToGeneratedMail(IWebDriver driver, WebDriverWait wait, string email)
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver, wait);
            priceCalculatorPage.SendEstimatedCostByEmail(email);
        }

        public string GetEstimatedCostFromEmail(IWebDriver driver, WebDriverWait wait)
        {
            EmailPage emailPage = new EmailPage(driver, wait);
            string result =  emailPage.CheckInbox()
                .RefreshInbox()
                .ReadMostRecentEmail()
                .ParseCostFromEmailContent();
            return result;
        }

        public string GetEstimatedCostFromCalculator(IWebDriver driver, WebDriverWait wait)
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver, wait);            
            string result = priceCalculatorPage.GetEstimatedCost(); 
            return result;
        }
    }
}
