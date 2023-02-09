using OpenQA.Selenium;
using PracticalTasks.Model;
using PracticalTasks.Pages;
using PracticalTasks.Services;
using System.Reflection;

namespace PracticalTasks.TestSteps
{
    public class Steps
    {
        public void OpenCalculatorPageBySearchRequest(IWebDriver driver)
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.OpenPage();
            mainPage.StartSearchFor(TestDataReader.GetTestData("testdata.searchRequest"));
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.GoToSearchResultPage();
        }

        public string CheckResultsAfterSearch(IWebDriver driver)
        {
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            searchResultsPage.OpenPage();
            string result = searchResultsPage.GetFirstSearchResult();
            return result;
        }

        public void FillCalculatorForm(IWebDriver driver)
        {
            ServerInstance server = CreateServer.WithPresetFromProperty();
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.FillForm(server);
        }

        public void OpenNewBrowserTab(IWebDriver driver)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
        }

        public string GenerateTempEmail(IWebDriver driver)
        {
            EmailPage emailPage = new EmailPage(driver);
            emailPage.OpenPage();
            string result = emailPage.GenerateEmail()
                .CopyGeneratedEmail();
            return result;
        }

        public void SwitchBackToLastBrowserTab(IWebDriver driver, int tabNumber)
        {
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[tabNumber]);
        }

        public void SendReportToGeneratedMail(IWebDriver driver, string email)
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);
            priceCalculatorPage.SendEstimatedCostByEmail(email);
        }

        public string GetEstimatedCostFromEmail(IWebDriver driver)
        {
            EmailPage emailPage = new EmailPage(driver);
            string result =  emailPage.CheckInbox()
                .RefreshInbox()
                .ReadMostRecentEmail()
                .ParseCostFromEmailContent();
            return result;
        }

        public string GetEstimatedCostFromCalculator(IWebDriver driver)
        {
            PriceCalculatorPage priceCalculatorPage = new PriceCalculatorPage(driver);            
            string result = priceCalculatorPage.GetEstimatedCost(); 
            return result;
        }

        public void DisposeTest(IWebDriver driver)
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var screenshotsDirectory = Path.Combine(directory, "Screenshots");
            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }
            var filePath = Path.Combine(screenshotsDirectory, $"{screenshotName}.png");

            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured while taking screenshot: {e.Message}");
            }
        }
    }
}
