using OpenQA.Selenium;
using PracticalTasks.Driver;
using PracticalTasks.Model;
using PracticalTasks.Pages;
using PracticalTasks.Services;

namespace PracticalTasks.TestSteps
{
    public class Steps
    {
        private IWebDriver driver;

        public IWebDriver Driver => driver;

        public void InitializeBrowser()
        {
            driver = WebDriverManager.GetInstance();
        }

        public void OpenCalculatorPageBySearchRequest()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.StartSearchFor(TestDataReader.GetTestData("testdata.searchRequest"));
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.GoToSearchResultPage();
        }

        public string CheckResultsAfterSearch()
        {
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            string result = searchResultsPage.GetFirstSearchResult();

            return result;
        }

        public void FillCalculatorForm()
        {
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.FillForm(server);
        }

        public void OpenNewBrowserTab()
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public string GenerateTempEmail()
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.OpenPage();
            string result = emailPage.GenerateEmail()
                .CopyGeneratedEmail();
            return result;
        }

        public void SwitchBackToLastBrowserTab(int tabNumber)
        {
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[tabNumber]);
        }

        public void SendReportToGeneratedMail(string email)
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.SendEstimatedCostByEmail(email);
        }

        public string GetEstimatedCostFromEmail()
        {
            EmailPage emailPage = new EmailPage(driver);
            string result =  emailPage.CheckInbox()
                .RefreshInbox()
                .ReadMostRecentEmail()
                .ParseCostFromEmailContent();
            return result;
        }

        public string GetEstimatedCostFromCalculator()
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);            
            string result = priceCalculatorPage.GetEstimatedCost(); 
            return result;
        }
    }
}
