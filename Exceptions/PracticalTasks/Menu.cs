using PracticalTasks.VehicleAssembling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public class Menu
    {
        public static void DisplayList(List<Vehicle> vehicleList)
        {
            vehicleList = (
                                from v in DataHandler.LoadedVehicleList.Root.Elements("Vehicle")
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

            if (vehicleList.Count == 0)
            {
                Console.WriteLine("List is empty. Please add a vehicle.\n");
                GetBackToMenu();
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

        public static void GetBackToMenu()
        {
            Console.WriteLine("1. ADD VEHICLE\n2. EDIT VEHICLE\n3. DELETE VEHICLE\n4. FILTER LIST BY PARAMETER");

            uint action;
            while (!uint.TryParse(Console.ReadLine(), out action) || action == 0 || action > 4)
            {
                Console.WriteLine("Please choose the further action by typing a number from 1 to 3.");
            }

            switch (action)
            {
                case 1:
                    VehiclesManagement.CollectDataForVehicle();
                    VehiclesManagement.AddVehicle();
                    break;
                case 2:
                    VehiclesManagement.UpdateVehicle();
                    break;
                case 3:
                    VehiclesManagement.RemoveVehicle();
                    break;
                default:
                    FilterList();
                    break;
            }
        }
    }
}
