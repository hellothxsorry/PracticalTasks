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
        public void LocateSearchFieldByXpathAxesTest()
        {
            IWebElement searchFieldInput = driver.FindElement(By.XPath("//a[contains(@href,'search')]/child::span[contains(text(),'Search BBC')]"));

            Assert.NotNull(searchFieldInput);
            Assert.True(searchFieldInput.Displayed);
        }

        [Fact]
        public void LocateAllSportsButtonByXpathAxesTest()
        {
            IWebElement allSportsButton = driver.FindElement(
                By.XPath("//div[@id='product-navigation-menu']/descendant::a[contains(@href,'all-sports') and not(contains(@aria-controls,'more'))]"));

            Assert.NotNull(allSportsButton);
            Assert.True(allSportsButton.Displayed);
        }

        [Fact]
        public void LocateBbcLogoByXpathAxesTest()
        {
            IWebElement bbcLogo = driver.FindElement(By.XPath("//span[contains(@class,'LogoIconWrapper')]/parent::a"));

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
