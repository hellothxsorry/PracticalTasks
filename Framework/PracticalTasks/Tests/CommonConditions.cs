using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PracticalTasks.Driver;
using PracticalTasks.TestSteps;
using Xunit;

namespace PracticalTasks.Tests
{
    public class CommonConditions: IClassFixture<WebDriverFixture>
    {
        protected readonly IWebDriver driver;
        protected readonly WebDriverWait wait;
        protected Steps Steps { get; private set; }

        public CommonConditions(WebDriverFixture webDriverFixture)
        {
            driver = webDriverFixture.Driver;
            wait = webDriverFixture.Wait;
            Steps = new Steps();
        }
    }
}
