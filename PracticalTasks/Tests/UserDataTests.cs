using OpenQA.Selenium;
using Xunit;
using PracticalTasks.PageObjects;
using PracticalTasks.Utils;

namespace PracticalTasks.Tests
{
    public class UserDataTests: IClassFixture<WebDriverFixture>
    {
        private WebDriverFixture fixture;

        public UserDataTests(WebDriverFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CanChangeUsername()
        {

        }

        [Fact]
        public void ShouldHaveNewUsername()
        {

        }
    }
}
