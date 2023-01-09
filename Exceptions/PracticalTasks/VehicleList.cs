using PracticalTasks.VehicleParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PracticalTasks
{
    public class VehicleList
    {
        private List<Vehicle> vehicleList;

        private VehicleList()
        {
            vehicleList = new List<Vehicle>();
        }

        public void AddVehicle(Vehicle newVehicle)
        {
            vehicleList.Add(newVehicle);
        }

        public void RemoveVehicle(int vehicleID)
        {
            vehicleList.RemoveAt(vehicleID);
        }

        public List<Vehicle> GetActualList()
        {     
            return vehicleList;
        }

        public void ReloadData()
        {
            try
            {
                LoadXMLFile();
            }
            catch
            {
                SaveXMLFile();
                LoadXMLFile();
            }


            if (vehicleList.Count == 0)
            {
                Console.WriteLine("List is empty. Please add a vehicle.\n");
            }
            else
            {
                string centeredTitle = "List of Vehicles:";
                Console.SetCursorPosition((Console.WindowWidth - centeredTitle.Length) / 2, Console.CursorTop);
                Console.WriteLine(centeredTitle);

                for (int i = 0; i < vehicleList.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. Model: {vehicleList[i].name} | Type: {vehicleList[i].type}\n" +
                        $"Engine power: {vehicleList[i].engine.Power} horsepower | E.volume: {vehicleList[i].engine.Volume}L | E.type: {vehicleList[i].engine.Type} | E.serial#: {vehicleList[i].engine.SerialNumber}\n" +
                        $"Number of wheels: {vehicleList[i].chassis.WheelsNumber} | Chassis VIN: {vehicleList[i].chassis.VINumber} | Permissible load: {vehicleList[i].chassis.PermissibleLoad}KG\n" +
                        $"Transmission type: {vehicleList[i].transmission.Type} | Number of gears: {vehicleList[i].transmission.NumberOfGears} | T.manufacturer: {vehicleList[i].transmission.Manufacturer}\n");
                    if (i == vehicleList.Count - 1)
                    {
                        Console.Write("---------- ---------- ---------- ---------- ---------- ---------- ----------\n");
                    }
                }
            }
        }

        private void LoadXMLFile()
        {
            var loadedVehicleList = XDocument.Load(@"..\AllVehicles.xml");

            vehicleList = (
                        from v in loadedVehicleList.Root.Elements("Vehicle")
                        select new Vehicle
                        {
                            name = (string)v.Element("Name"),
                            type = (VehicleTypes)Enum.Parse(typeof(VehicleTypes), (string)v.Element("VehicleType")),
                            engine = new Engine(
                            (uint)v.Element("EnginePower"),
                            (double)v.Element("EngineVolume"),
                            (string)v.Element("EngineType"),
                            (string)v.Element("EngineSerial")),
                            chassis = new Chassis(
                            (uint)v.Element("WheelsNum"),
                            (string)v.Element("VIN"),
                            (double)v.Element("PermissibleLoad")),
                            transmission = new Transmission(
                            (string)v.Element("TransmissionType"),
                            (uint)v.Element("GearsNum"),
                            (string)v.Element("TransmissionManufacturer"))
                        })
                        .ToList();
        }

        public void SaveXMLFile()
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

        private static readonly Lazy<VehicleList> instance =
            new Lazy<VehicleList>(() => new VehicleList());

        public static VehicleList Instance => instance.Value;
    }
}
