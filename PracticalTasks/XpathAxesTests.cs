using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PracticalTasks
{
    public class XpathAxesTests : IDisposable
    {
        private IWebDriver driver;
        private const string BaseUrl = "https://www.bbc.com/sport";

        public XpathAxesTests()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [Fact]
        public void CanLocateSearchFieldByXpathAxesTests()
        {
            IWebElement searchFieldInput = driver.FindElement(
                By.XPath("//div[@role='search' and @aria-label='Search BBC']/" +
                "*[@href='https://www.bbc.co.uk/search?d=SPORT_GNL']"));

            Assert.NotNull(searchFieldInput);
            Assert.True(searchFieldInput.Displayed);
        }

        [Fact]
        public void CanLocateAllSportsButtonByXpathAxesTests()
        {
            IWebElement allSportsButton = driver.FindElement(
                By.XPath("//a[@href='/sport/all-sports' and " +
                "@class='ssrcss-1kl7qyq-StyledToggle ekfn8591']/parent::div/preceding-sibling::div"));

            Assert.NotNull(allSportsButton);
            Assert.True(allSportsButton.Displayed);
        }

        [Fact]
        public void CanLocateBbcLogoByXpathAxesTests()
        {
            IWebElement bbcLogo = driver.FindElement(
                By.XPath("//a[@href='https://www.bbc.com' and @class=" +
                "'ssrcss-dkv2k4-NavigationLink-LogoLink e1gviwgp14']/ancestor::nav" +
                "[@aria-label='BBC' and @class='ssrcss-1a6al6l-ChameleonGlobalNavigation e140xmwz0']"));

            Assert.NotNull(bbcLogo);
            Assert.True(bbcLogo.Displayed);
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
