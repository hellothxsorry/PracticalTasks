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
        public void CanLocateSearchFieldByXpathAxesTest()
        {
            IWebElement searchFieldInput = driver.FindElement(By.XPath("//a[contains(@href,'search')]/child::span[text()='Search BBC']"));

            Assert.NotNull(searchFieldInput);
            Assert.True(searchFieldInput.Displayed);
        }

        [Fact]
        public void CanLocateAllSportsButtonByXpathAxesTest()
        {
            IWebElement allSportsButton = driver.FindElement(By.XPath("//div[@id='product-navigation-menu']/descendant::a[text()='More']"));

            Assert.NotNull(allSportsButton);
            Assert.True(allSportsButton.Displayed);
        }

        [Fact]
        public void CanLocateBbcLogoByXpathAxesTest()
        {
            IWebElement bbcLogo = driver.FindElement(By.XPath("//span[contains(text(),'Homepage')]/parent::span"));

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
