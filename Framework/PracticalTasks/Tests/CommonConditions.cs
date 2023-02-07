using OpenQA.Selenium;
using PracticalTasks.TestSteps;
using System.Reflection;
using Xunit.Abstractions;

namespace PracticalTasks.Tests
{
    public class CommonConditions: IDisposable
    {
        protected Steps steps = new Steps();
        private ITestOutputHelper output;

        public void Dispose()
        {
            var screenshotName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var screenshotsDirectory = Path.Combine(directory, "Screenshots");
            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(screenshotsDirectory);
            }
            var filePath = Path.Combine(screenshotsDirectory, $"{screenshotName}.png");

            try
            {
                var screenshot = ((ITakesScreenshot)steps.Driver).GetScreenshot();
                screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
            }
            catch (Exception e)
            {
                output.WriteLine($"Error occured while taking screenshot: {e.Message}");
            }

            steps.Driver.Quit();
            steps.Driver.Dispose();
        }
    }
}
