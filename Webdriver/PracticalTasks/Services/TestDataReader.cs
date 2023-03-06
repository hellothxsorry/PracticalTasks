using Newtonsoft.Json;

namespace PracticalTasks.Services
{
    public static class TestDataReader
    {
        private static readonly Dictionary<string, string> TestData = new Dictionary<string, string>();

        public static string GetTestData(string key)
        {
            if (TestData.Count == 0)
            {
                var testDataJson = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(File.ReadAllText("TestData/TestData.json"))[0];

                foreach (var pair in testDataJson)
                {
                    TestData.Add(pair.Key, pair.Value);
                }
            }
            return TestData[key];
        }
    }
}