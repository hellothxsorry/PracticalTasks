using OpenQA.Selenium;
using PracticalTasks.Driver;
using PracticalTasks.TestSteps;
using Xunit;

namespace PracticalTasks.Tests
{
    public class CommonConditions: IClassFixture<WebDriverFixture>
    {
        protected readonly IWebDriver driver;
        protected Steps Steps { get; set; }

        public CommonConditions(WebDriverFixture webDriverFixture)
        {
            driver = webDriverFixture.Driver;
            Steps = new Steps();
        }
    }
}
