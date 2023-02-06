using System.Configuration;

namespace PracticalTasks.Services
{
    public class TestDataReader
    {
        public static string GetTestData(string key)
        {
            return ConfigurationManager.AppSettings[key] ?? string.Empty;
        }
    }
}
