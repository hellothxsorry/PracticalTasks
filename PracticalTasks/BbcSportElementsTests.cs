using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalTasks
{
    public class BbcSportElementsTests : IDisposable
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://www.bbc.com/sport";
        private static readonly By asd = By.Id("");

        public BbcSportElementsTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [Fact]
        public void CanLocateSearchFieldTest()
        {
            IWebElement searchFieldInput = driver.FindElement(By.XPath("//div[@role='search']"));

            Assert.NotNull(searchFieldInput);
            Assert.True(searchFieldInput.Displayed);
        }

        [Fact]
        public void CanLocateAllSportsButtonTest()
        {
            IWebElement allSportsButton = driver.FindElement(By.CssSelector("[aria-controls='product-navigation-more-menu']"));
            allSportsButton.Click();

        }

        [Fact]
        public void CanLocateBbcLogoTest()
        {
            IWebElement bbcIcon = driver.FindElement(By.XPath("//span[contains(text(),'Homepage')]/parent::span"));

            Assert.NotNull(bbcIcon);
            Assert.True(bbcIcon.Displayed);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}