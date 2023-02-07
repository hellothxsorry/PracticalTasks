using Newtonsoft.Json;

namespace PracticalTasks.Services
{
    public class TestDataReader
    {
        private static readonly Dictionary<string, string> TestData = new Dictionary<string, string>();

        public static string GetTestData(string key)
        {
            if (TestData.Count == 0)
            {
                var environment = Environment.GetEnvironmentVariable("Environment") ?? "qa";
                environment = environment.Trim();

                var testDataFile = $"Properties/testdata-{environment}.json";
                var testDataJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(testDataFile));

                foreach (var pair in testDataJson)
                {
                    TestData.Add(pair.Key, pair.Value);
                }
            }            

            return TestData[key];
        }
    }
}
