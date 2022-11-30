namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            List <Vehicle> vehicles = new List<Vehicle>
            {                
                new PassengerCar("Ford", 72, "USA CC", 120, new Engine(-300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Bus("MCI", BusTypes.School, 72, new Engine(250, 7.0, "Diesel", "I5UUK571C0"),
                    new Chassis(4, "OJ924UI0733Y7990K", 10000), new Transmission("Automatic", 4, "MCI")),
                new Truck("Ram", "EuroT", 8, new Engine(700, 6.5, "V8", "CAF7770A07"),
                    new Chassis(6, "RQ100BH9801AQ5C01", 2500), new Transmission("Automatic", 10, "ZF")),
                new Scooter("Apollo", true, new Engine(8, 1.2, "4-stroke", "C00751370C10"), FuelType.Gas,
                    new Chassis(2, "I542O9A5HH3330FW0", 150), new Transmission("CVT", 0, "Electro Innov"))
            };

            foreach (Vehicle v in vehicles)
            {
                v.InformationOutput();
            }
        }
    }
}
