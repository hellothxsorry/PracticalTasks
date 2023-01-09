using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using PracticalTasks.VehicleAssembling;

namespace PracticalTasks
{
    public class DataHandler
    {
        public static XDocument? LoadedVehicleList;
        public static List<Vehicle>? VehicleList = new List<Vehicle>();

        public static void LoadList()
        {
            try
            {
                LoadedVehicleList = XDocument.Load(@"..\AllVehicles.xml");
            }
            catch
            {
                Console.WriteLine("There is no any existent list of vehicles or the list got corrupted. Please add a new vehicle to create list.");
                VehiclesManagement.CollectDataForVehicle();
                VehiclesManagement.AddVehicle();
                Menu.GetBackToMenu();
            }
        }

        public static void SaveCurrentData(List<Vehicle> vehicleList)
        {
            var allVehiclesCollectionData = new XElement("Vehicles",
                                     from v in vehicleList
                                     select new XElement("Vehicle",
                                                    new XElement("Name", v.name),
                                                    new XElement("VehicleType", v.type),
                                                    new XElement("EnginePower", v.engine.Power),
                                                    new XElement("EngineVolume", v.engine.Volume),
                                                    new XElement("EngineType", v.engine.Type),
                                                    new XElement("EngineSerial", v.engine.SerialNumber),
                                                    new XElement("WheelsNum", v.chassis.WheelsNumber),
                                                    new XElement("VIN", v.chassis.VINumber),
                                                    new XElement("PermissibleLoad", v.chassis.PermissibleLoad),
                                                    new XElement("TransmissionType", v.transmission.Type),
                                                    new XElement("GearsNum", v.transmission.NumberOfGears),
                                                    new XElement("TransmissionManufacturer", v.transmission.Manufacturer)));

            allVehiclesCollectionData.Save(@"..\AllVehicles.xml");
        }

        public static void FilterList(List<Vehicle> vehicleList)
        {
            Console.Clear();
            Menu.DisplayList(vehicleList);
            Console.WriteLine("1. HIDE VEHICLES WITH ENGINE VOLUME LESS THAN 1.5L\n" +
                "2. SHOW ONLY HEAVY VEHICLES\n3. SHOW ONLY MANUAL TRANSMISSIONS\n4. SHOW ONLY AUTOMATIC TRANSMISSIONS\n5. SHOW ONLY CVT TRANSMISSIONS");

            uint action;
            while (!uint.TryParse(Console.ReadLine(), out action) || action == 0 || action > 4)
            {
                Console.WriteLine("Please choose the preferable filter by typing a number from 1 to 4.");
            }

            IEnumerable<Vehicle> bufferVehicleList;
            var engineCapacity = vehicleList?.Where(x => x.engine.Volume > 1.5).Select(x => x);
            var allHeavy = vehicleList?.Where(x => x.type == VehicleTypes.Truck || x.type == VehicleTypes.Bus).Select(x => x);
            var transmissionManual = vehicleList?.Where(x => x.transmission.Type == "Manual").Select(x => x);
            var transmissionAutomatic = vehicleList?.Where(x => x.transmission.Type == "Automatic").Select(x => x);
            var transmissionCvt = vehicleList?.Where(x => x.transmission.Type == "CVT").Select(x => x);

            switch (action)
            {
                case 1:
                    bufferVehicleList = engineCapacity;
                    break;
                case 2:
                    bufferVehicleList = allHeavy;
                    break;
                case 3:
                    bufferVehicleList = transmissionManual;
                    break;
                case 4:
                    bufferVehicleList = transmissionAutomatic;
                    break;
                default:
                    bufferVehicleList = transmissionCvt;
                    break;
            }

            try
            {
                if (bufferVehicleList.Count() == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Sorry, there is no vehicle matching the request.\n");
                }
                else
                {
                    for (int i = 0; i < bufferVehicleList.Count(); i++)
                    {
                        Console.WriteLine(
                            $"{i + 1}. Model: {bufferVehicleList.ElementAt(i).name} | Type: {bufferVehicleList.ElementAt(i).type}\n" +
                            $"Engine power: {bufferVehicleList.ElementAt(i).engine.Power} horsepower | E.volume: {bufferVehicleList.ElementAt(i).engine.Volume}L | E.type: {bufferVehicleList.ElementAt(i).engine.Type} | E.serial#: {bufferVehicleList.ElementAt(i).engine.SerialNumber}\n" +
                            $"Number of wheels: {bufferVehicleList.ElementAt(i).chassis.WheelsNumber} | Chassis VIN: {bufferVehicleList.ElementAt(i).chassis.VINumber} | Permissible load: {bufferVehicleList.ElementAt(i).chassis.PermissibleLoad}KG\n" +
                            $"Transmission type: {bufferVehicleList.ElementAt(i).transmission.Type} | Number of gears: {bufferVehicleList.ElementAt(i).transmission.NumberOfGears} | T.manufacturer: {bufferVehicleList.ElementAt(i).transmission.Manufacturer}\n");
                        if (i == bufferVehicleList.Count() - 1)
                        {
                            Console.Write("---------- ---------- ---------- ---------- ---------- ---------- ----------\n");
                        }
                    }
                }
                Menu.GetBackToMenu();
            }
            catch
            {
                Console.WriteLine("\nFiltering failed.\n");
                Menu.GetBackToMenu();
            }
        }
    }
}
