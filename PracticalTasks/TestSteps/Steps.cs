using OpenQA.Selenium;
using PracticalTasks.Driver;

namespace PracticalTasks.TestSteps
{
    public class Steps
    {
        private IWebDriver driver;
        public IWebDriver Driver => driver;


        public void InitializeBrowser()
        {
            driver = WebDriverManager.GetInstance();
        }
    }
}
