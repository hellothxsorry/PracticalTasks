using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PracticalTasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            SerializeListToXmlFile();
            Console.ReadKey();
        }

        private static void SerializeListToXmlFile()
        {
            List<Vehicle> vehicles = new List<Vehicle>
            {
                new Vehicle("Ford", VehicleTypes.PassengerCar, new Engine(300, 3.5, "V6", "D100928E01"),
                    new Chassis(4, "JT152EEA100302159", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Vehicle("GMC", VehicleTypes.Truck, new Engine(450, 5.0, "V8", "580307R155355"),
                    new Chassis(4, "MN3MS37A9PW202929", 1500), new Transmission("Manual", 10, "Ford Motor Company")),
                new Vehicle("TEMSA", VehicleTypes.Bus, new Engine(240, 6.7, "Diesel", "719179A333791"),
                    new Chassis(4, "CA5RT51R7OS313571", 16000), new Transmission("Manual", 4, "Jasper")),
                new Vehicle("Yamaha", VehicleTypes.Scooter, new Engine(12, 1.5, "4-stroke", "005101AA03577"),
                    new Chassis(2, "BB9ZQ00C91Y257233", 100), new Transmission("CVT", 0, "Aeon")),
                new Vehicle("Honda", VehicleTypes.PassengerCar, new Engine(350, 4.0, "V6", "E993157A77"),
                    new Chassis(4, "AA093KGZQ42115031", 450), new Transmission("Manual", 5, "HPPG")),
                new Vehicle("Ram", VehicleTypes.Truck, new Engine(700, 6.5, "V8", "CAF7770A07"),
                    new Chassis(6, "RQ100BH9801AQ5C01", 2500), new Transmission("Automatic", 10, "ZF")),
                new Vehicle("MCI", VehicleTypes.Bus, new Engine(250, 7.0, "Diesel", "I5UUK571C0"),
                    new Chassis(4, "OJ924UI0733Y7990K", 10000), new Transmission("Automatic", 4, "MCI")),
                new Vehicle("Apollo", VehicleTypes.Scooter, new Engine(8, 1.2, "4-stroke", "C00751370C10"),
                    new Chassis(2, "I542O9A5HH3330FW0", 150), new Transmission("CVT", 0, "Electro Innov")),
                new Vehicle("Iveco", VehicleTypes.Truck, new Engine(500, 4.5, "V8", "GF11043D82"),
                    new Chassis(6, "O77X305OS7624A30A", 420), new Transmission("Automatic", 6, "Aisin-Warner")),
                new Vehicle("Gogoro", VehicleTypes.Scooter, new Engine(10, 0.0, "Electric", "S0JPP000E57"),
                    new Chassis(2, "AA081CBW7155013JJ", 100), new Transmission("CVT", 0, "Gogoro")),
                new Vehicle("Tesla", VehicleTypes.PassengerCar, new Engine(1000, 0.0, "Electric", "T0S1LL0A01"),
                    new Chassis(4, "MS001TSL01101AA01", 700), new Transmission("Automatic", 5, "Tesla"))
            };

            #region Requirements from the task
            var engineCapacity = vehicles.Where(x => x.engine.Volume > 1.5).Select(x => x);

            var allHeavy = vehicles.Where(x => x.type == VehicleTypes.Truck || x.type == VehicleTypes.Bus).Select(x => x);

            var transmissionManual = vehicles.Where(x => x.transmission.Type == "Manual").Select(x => x);
            var transmissionAutomatic = vehicles.Where(x => x.transmission.Type == "Automatic").Select(x => x);
            var transmissionCvt = vehicles.Where(x => x.transmission.Type == "CVT").Select(x => x);
            #endregion

            var engineVolumeData = new XElement("Vehicles",
                                         from veh in engineCapacity
                                         select new XElement("Vehicle",
                                                        new XElement("Name", veh.name),
                                                        new XElement("VehicleType", veh.type),
                                                        new XElement("EnginePower", veh.engine.Power),
                                                        new XElement("EngineVolume", veh.engine.Volume),
                                                        new XElement("EngineType", veh.engine.Type),
                                                        new XElement("EngineSerial", veh.engine.SerialNumber),
                                                        new XElement("WheelsNum", veh.chassis.WheelsNumber),
                                                        new XElement("VIN", veh.chassis.VINumber),
                                                        new XElement("PermissibleLoad", veh.chassis.PermissibleLoad),
                                                        new XElement("TransmissionType", veh.transmission.Type),
                                                        new XElement("GearsNum", veh.transmission.NumberOfGears),
                                                        new XElement("TransmissionManufacturer", veh.transmission.Manufacturer)));                                                   


            var heavyVehicleData = new XElement("Vehicles",
                                         from veh in allHeavy
                                         select new XElement("Vehicle",
                                                        new XElement("VehicleType", veh.type),
                                                        new XElement("Name", veh.name),                                                        
                                                        new XElement("EnginePower", veh.engine.Power),
                                                        new XElement("EngineType", veh.engine.Type),
                                                        new XElement("EngineSerial", veh.engine.SerialNumber)));

            var transmissionGroupData = new XElement("Vehicles",
                                                new XElement("Manual",
                                                        from veh in transmissionManual
                                                        select new XElement("Vehicle",
                                                                    new XElement("Name", veh.name),
                                                                    new XElement("VehicleType", veh.type),
                                                                    new XElement("EnginePower", veh.engine.Power),
                                                                    new XElement("EngineVolume", veh.engine.Volume),
                                                                    new XElement("EngineType", veh.engine.Type),
                                                                    new XElement("EngineSerial", veh.engine.SerialNumber),
                                                                    new XElement("WheelsNum", veh.chassis.WheelsNumber),
                                                                    new XElement("VIN", veh.chassis.VINumber),
                                                                    new XElement("PermissibleLoad", veh.chassis.PermissibleLoad),
                                                                    new XElement("GearsNum", veh.transmission.NumberOfGears),
                                                                    new XElement("TransmissionManufacturer", veh.transmission.Manufacturer))),
                                                new XElement("Automatic",
                                                        from veh in transmissionManual
                                                        select new XElement("Vehicle",
                                                                    new XElement("Name", veh.name),
                                                                    new XElement("VehicleType", veh.type),
                                                                    new XElement("EnginePower", veh.engine.Power),
                                                                    new XElement("EngineVolume", veh.engine.Volume),
                                                                    new XElement("EngineType", veh.engine.Type),
                                                                    new XElement("EngineSerial", veh.engine.SerialNumber),
                                                                    new XElement("WheelsNum", veh.chassis.WheelsNumber),
                                                                    new XElement("VIN", veh.chassis.VINumber),
                                                                    new XElement("PermissibleLoad", veh.chassis.PermissibleLoad),
                                                                    new XElement("GearsNum", veh.transmission.NumberOfGears),
                                                                    new XElement("TransmissionManufacturer", veh.transmission.Manufacturer))),
                                                new XElement("CVT",
                                                        from veh in transmissionManual
                                                        select new XElement("Vehicle",
                                                                    new XElement("Name", veh.name),
                                                                    new XElement("VehicleType", veh.type),
                                                                    new XElement("EnginePower", veh.engine.Power),
                                                                    new XElement("EngineVolume", veh.engine.Volume),
                                                                    new XElement("EngineType", veh.engine.Type),
                                                                    new XElement("EngineSerial", veh.engine.SerialNumber),
                                                                    new XElement("WheelsNum", veh.chassis.WheelsNumber),
                                                                    new XElement("VIN", veh.chassis.VINumber),
                                                                    new XElement("PermissibleLoad", veh.chassis.PermissibleLoad),
                                                                    new XElement("GearsNum", veh.transmission.NumberOfGears),
                                                                    new XElement("TransmissionManufacturer", veh.transmission.Manufacturer))));

            engineVolumeData.Save(@"..\EngineVolumesFiltered.xml");
            heavyVehicleData.Save(@"..\HeavyVehiclesFiltered.xml");
            transmissionGroupData.Save(@"..\TransmissionGroupsFiltered.xml");     

            Console.WriteLine("The XML files are created!");              
        }
    }
}
