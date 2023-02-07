using PracticalTasks.Model;
using System.Configuration;

namespace PracticalTasks.Services
{
    public class CreateServer
    {
        public static readonly string TestDataNumberOfInstances = "testdata.server.numberOfInstances";
		public static readonly string TestDataOperatingSystem = "testdata.server.operatingSystem";
		public static readonly string TestDataInstanceSeries = "testdata.server.instanceSeries";
		public static readonly string TestDataInstanceType = "testdata.server.instanceType";
		public static readonly string TestDataNumberOfGpu = "testdata.server.numberOfGpu";
		public static readonly string TestDataGpuType = "testdata.server.gpuType";
		public static readonly string TestDataLocalSsd = "testdata.server.localSsd";
		public static readonly string TestDataDatacenterLocation = "testdata.server.datacenterLocation";
		public static readonly string TestDataCommittedUsage = "testdata.server.committedUsage";

		public static ServerInstance WithPresetFromProperty()
        {
			return new ServerInstance(TestDataReader.GetTestData(TestDataNumberOfInstances),
				TestDataReader.GetTestData(TestDataOperatingSystem),
				TestDataReader.GetTestData(TestDataInstanceSeries),
				TestDataReader.GetTestData(TestDataInstanceType),
				TestDataReader.GetTestData(TestDataNumberOfGpu),
				TestDataReader.GetTestData(TestDataGpuType),
				TestDataReader.GetTestData(TestDataLocalSsd),
				TestDataReader.GetTestData(TestDataDatacenterLocation),
				TestDataReader.GetTestData(TestDataCommittedUsage));
        } 
    }
}
