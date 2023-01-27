using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalTasks
{
    public class BbcSportElementsTests : IDisposable
    {
        private IWebDriver driver;

        [Fact]
        public void TestSearchField()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement searchField = driver.FindElement(
                By.CssSelector("div[aria-label='Search BBC'][role='search']" +
                "[class='ssrcss-1j3alh1-GlobalNavigationItem e1gviwgp23']"));

            Assert.NotNull(searchField);
        }

        [Fact]
        public void TestAllSportsButton()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement allSportsButton = driver.FindElement(By.LinkText("More"));

            Assert.NotNull(allSportsButton);
        }

        [Fact]
        public void TestBbcLogo()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement bbcIcon = driver.FindElement(
                By.XPath("/html/body/div[2]/div/div/div[1]/div/header/nav/div[1]/div/div[1]/a"));

            Assert.NotNull(bbcIcon);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}