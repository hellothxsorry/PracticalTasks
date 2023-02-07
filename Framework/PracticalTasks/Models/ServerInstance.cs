using PracticalTasks.Pages;

namespace PracticalTasks.Model
{
    public class ServerInstance
    {
        public string NumberOfInstances { get; set; }
        public string OperatingSystem { get; set; }
        public string InstanceSeries { get; set; }
        public string InstanceType { get; set; }
        public string NumberOfGpu { get; set; }
        public string GpuType { get; set; }
        public string LocalSsd { get; set; }
        public string DatacenterLocation { get; set; }
        public string CommittedUsage { get; set; }

        public ServerInstance(string numberOfInstances, string operatingSystem, 
            string instanceSeries, string instanceType, string numberOfGpu, string gpuType,
            string localSsd, string datacenterLocation, string committedUsage)
        {
            NumberOfInstances = numberOfInstances;
            OperatingSystem = operatingSystem;
            InstanceSeries = instanceSeries;
            InstanceType = instanceType;
            NumberOfGpu = numberOfGpu;
            GpuType = gpuType;
            LocalSsd = localSsd;
            DatacenterLocation = datacenterLocation;
            CommittedUsage = committedUsage;
        }      
    }
}
