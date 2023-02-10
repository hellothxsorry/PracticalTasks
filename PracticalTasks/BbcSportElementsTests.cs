using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalTasks
{
    public class BbcSportElementsTests : IDisposable
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://www.bbc.com/sport";

        public BbcSportElementsTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [Fact]
        public void CanLocateSearchFieldTest()
        {
            IWebElement searchFieldInput = driver.FindElement(
                By.CssSelector("div[aria-label='Search BBC'][role='search']" +
                "[class='ssrcss-1j3alh1-GlobalNavigationItem e1gviwgp23']"));

            Assert.NotNull(searchFieldInput);
            Assert.True(searchFieldInput.Displayed);
        }

        [Fact]
        public void CanLocateAllSportsButtonTest()
        {
            IWebElement allSportsButton = driver.FindElement(By.LinkText("More"));

            Assert.NotNull(allSportsButton);
            Assert.True(allSportsButton.Displayed);
        }

        [Fact]
        public void CanLocateBbcLogoTest()
        {
            IWebElement bbcIcon = driver.FindElement(
                By.XPath("/html/body/div[2]/div/div/div[1]/div/header/nav/div[1]/div/div[1]/a"));

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