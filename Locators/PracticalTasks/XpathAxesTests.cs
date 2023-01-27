using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalTasks
{
    public class XpathAxesTests : IDisposable
    {
        private IWebDriver driver;

        [Fact]
        public void TestSearchField()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement searchField = driver.FindElement(
                By.XPath("//div[@role='search' and @aria-label='Search BBC']/" +
                "*[@href='https://www.bbc.co.uk/search?d=SPORT_GNL']"));

            Assert.NotNull(searchField);
        }

        [Fact]
        public void TestAllSportsButton()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement allSportsButton = driver.FindElement(
                By.XPath("//a[@href='/sport/all-sports' and " +
                "@class='ssrcss-1kl7qyq-StyledToggle ekfn8591']/parent::div/preceding-sibling::div"));

            Assert.NotNull(allSportsButton);
        }

        [Fact]
        public void TestBbcLogo()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement bbcLogo = driver.FindElement(
                By.XPath("//a[@href='https://www.bbc.com' and @class=" +
                "'ssrcss-dkv2k4-NavigationLink-LogoLink e1gviwgp14']/ancestor::nav" +
                "[@aria-label='BBC' and @class='ssrcss-1a6al6l-ChameleonGlobalNavigation e140xmwz0']"));

            Assert.NotNull(bbcLogo);
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
