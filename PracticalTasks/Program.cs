using PracticalTasks.VehicleParts;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace PracticalTasks
{
    public class Program
    {
        private static List<Vehicle>? vehicleList;
        private static XDocument? loadedVehicleList;
        private static string bufferName;
        private static VehicleTypes bufferVehicleType;
        private static uint bufferEnginePower;
        private static double bufferEngineVolume;
        private static string bufferEngineType;
        private static string bufferEngineSerial;
        private static uint bufferNumberOfWheels;
        private static string bufferVIN;
        private static double bufferLoadCapacity;
        private static string bufferTransmissionType;
        private static uint bufferNumberOfGears;
        private static string bufferTransmissionManufacturer;

        static void Main(string[] args)
        {
            LoadList();
            DisplayList();      
            GetBackToMenu();
        }

        public static void LoadList()
        {
            try
            {
                loadedVehicleList = XDocument.Load(@"..\AllVehicles.xml");   
            }
            catch
            {
                Console.WriteLine("There is no any existent list of vehicles or the list got corrupted. Please add at least one new vehicle and save the session to create a new list.");
                GetBackToMenu();
            }            
        }

        public static void DisplayList()
        {
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
                    CollectDataForVehicle();
                    CreateNewVehicle();
                    break;
                case 2:
                    UpdateVehicle();
                    break;
                case 3:
                    RemoveVehicle();
                    break;
                default:
                    FilterList();
                    break;
            }
        }  
        
        public static void SaveCurrentData()
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

        public static void FilterList()
        {
            Console.Clear();
            Console.WriteLine("1. HIDE VEHICLES WITH ENGINE VOLUME LESS THAN 1.5L\n" +
                "2. SHOW ONLY HEAVY VEHICLES\n3. SHOW ONLY MANUAL TRANSMISSIONS\n4. SHOW ONLY AUTOMATIC TRANSMISSIONS\n5. SHOW ONLY CVT TRANSMISSIONS");

            uint action;
            while (!uint.TryParse(Console.ReadLine(), out action) || action == 0 || action > 4)
            {
                Console.WriteLine("Please choose the preferable filter by typing a number from 1 to 4.");
            }

            try
            {
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
                GetBackToMenu();
            }
            catch
            {
                Console.WriteLine("\nSorry, there is no vehicle matching the request.\n");
                GetBackToMenu();
            }
        }

        public static void CollectDataForVehicle()
        {     
            Console.Clear();
            Console.WriteLine("Please type a vehicle name:");
            bufferName = Console.ReadLine();

            Console.Clear();
            uint vehicleTypeInput;
            Console.WriteLine("Please choose a vehicle type:\n" +
                "1 - Passenger Car\n2 - Truck\n3 - Bus\n4 - Scooter\n");
            while (!uint.TryParse(Console.ReadLine(), out vehicleTypeInput) || vehicleTypeInput == 0 || vehicleTypeInput > 4)
            {
                Console.WriteLine("Please enter a number between 1 and 4 to choose a vehicle type:");
            }
            switch (vehicleTypeInput)
            {
                case 1:
                    bufferVehicleType = VehicleTypes.PassengerCar;
                    break;
                case 2:
                    bufferVehicleType = VehicleTypes.Truck;
                    break;
                case 3:
                    bufferVehicleType = VehicleTypes.Bus;
                    break;
                default:
                    bufferVehicleType = VehicleTypes.Scooter;
                    break;
            }

            Console.Clear();
            uint enginePowerInput;
            Console.WriteLine("Please enter a power of engine:");
            while (!uint.TryParse(Console.ReadLine(), out enginePowerInput) || enginePowerInput == 0)
            {
                Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
            }
            bufferEnginePower = enginePowerInput;

            Console.Clear();
            double engineVolumeInput;
            Console.WriteLine("Please enter a volume of engine:");
            while (!double.TryParse(Console.ReadLine(), out engineVolumeInput) || engineVolumeInput < 1)
            {
                Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
            }
            bufferEngineVolume = engineVolumeInput;

            Console.Clear();
            Console.WriteLine("Please describe an engine type:");
            bufferEngineType = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Please type an engine serial number:");
            bufferEngineSerial = Console.ReadLine();

            Console.Clear();
            uint wheelsNumberInput;
            Console.WriteLine("Please enter a number of wheels:");
            while (!uint.TryParse(Console.ReadLine(), out wheelsNumberInput) || wheelsNumberInput < 2)
            {
                Console.WriteLine("Wrong number of wheels (cannot be negative, 0 or 1). Please try again:");
            }
            bufferNumberOfWheels = wheelsNumberInput;

            Console.Clear();
            Console.WriteLine("Please enter a VIN of the chassis:");
            bufferVIN = Console.ReadLine();

            Console.Clear();
            double loadCapacityInput;
            Console.WriteLine("Please enter a maximum of a load capacity:");
            while (!double.TryParse(Console.ReadLine(), out loadCapacityInput) || loadCapacityInput < 1)
            {
                Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
            }
            bufferLoadCapacity = loadCapacityInput;

            Console.Clear();
            Console.WriteLine("Please describe a type of transmission:");
            bufferTransmissionType = Console.ReadLine();

            Console.Clear();
            uint gearsNumberInput;
            Console.WriteLine("Please enter a number of gears:");
            while (!uint.TryParse(Console.ReadLine(), out gearsNumberInput) || gearsNumberInput == 0)
            {
                Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
            }
            bufferNumberOfGears = gearsNumberInput;

            Console.Clear();
            Console.WriteLine("Please type a name of transmission manufacturer:");
            bufferTransmissionManufacturer = Console.ReadLine();                  
        }

        public static void CreateNewVehicle()
        {
            Console.Clear();
            string response;
            do
            {
                Console.WriteLine($"Model: {bufferName} | Type: {bufferVehicleType}\n" +
                $"Engine power: {bufferEnginePower} horsepower | E.volume: {bufferEngineVolume}L | E.type: {bufferEngineType} | E.serial#: {bufferEngineSerial}\n" +
                $"Number of wheels: {bufferNumberOfWheels} | Chassis VIN: {bufferVIN} | Permissible load: {bufferLoadCapacity}KG\n" +
                $"Transmission type: {bufferTransmissionType} | Number of gears: {bufferNumberOfGears} | T.manufacturer: {bufferTransmissionManufacturer}\n" +
                $"----------------------------------------------------------------------\n" +
                $"Proceed and add the vehicle above? Y/N");
                var input = Console.ReadLine();
                response = input?.ToLower();
                if (response == "y" || response == "n")
                {
                    break;
                }
            } while (true);

            if (response == "y")
            {
                Vehicle newVehicle = null;

                try
                {
                    newVehicle = new Vehicle(bufferName, bufferVehicleType, new Engine(bufferEnginePower, bufferEngineVolume,
                        bufferEngineType, bufferEngineSerial), new Chassis(bufferNumberOfWheels, bufferVIN, bufferLoadCapacity),
                        new Transmission(bufferTransmissionType, bufferNumberOfGears, bufferTransmissionManufacturer));
                }
                catch
                {
                    Console.WriteLine("Failed to initialize a new vehicle. Please try again.");
                    GetBackToMenu();
                }

                try
                {
                    vehicleList.Add(newVehicle);
                }
                catch
                {
                    Console.WriteLine("Attempt to add a new vehicle failed. Please try again.");
                    GetBackToMenu();
                }

                Console.Clear();
                SaveCurrentData();
                LoadList();
                DisplayList();
                Console.WriteLine("\nNew vehicle has been successfully added to the list!\n");
                GetBackToMenu();
            }
            else
            {
                Console.Clear();
                DisplayList();
                GetBackToMenu();
            }
        }

        public static void UpdateVehicle()
        {
            Console.Clear();
            DisplayList();
            try
            {
                uint idInput;

                Console.WriteLine("Please enter ID of the vehicle you want to edit:");
                while (!uint.TryParse(Console.ReadLine(), out idInput) || idInput == 0)
                {
                    Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
                }

                Console.Clear();
                int i = (int)idInput - 1;
                string response;
                do
                {
                    Console.WriteLine(
                       $"{i + 1}. Model: {vehicleList[i].name} | Type: {vehicleList[i].type}\n" +
                       $"Engine power: {vehicleList[i].engine.Power} horsepower | E.volume: {vehicleList[i].engine.Volume}L | E.type: {vehicleList[i].engine.Type} | E.serial#: {vehicleList[i].engine.SerialNumber}\n" +
                       $"Number of wheels: {vehicleList[i].chassis.WheelsNumber} | Chassis VIN: {vehicleList[i].chassis.VINumber} | Permissible load: {vehicleList[i].chassis.PermissibleLoad}KG\n" +
                       $"Transmission type: {vehicleList[i].transmission.Type} | Number of gears: {vehicleList[i].transmission.NumberOfGears} | T.manufacturer: {vehicleList[i].transmission.Manufacturer}\n" +
                       $"----------------------------------------------------------------------\n" +
                       $"Are you sure that you want to update this vehicle? Y/N");

                    var input = Console.ReadLine();
                    response = input?.ToLower();
                    if (response == "y" || response == "n")
                    {
                        break;
                    }
                } while (true);

                if (response == "y")
                {
                    Console.Clear();
                    CollectDataForVehicle();
                }
                else
                {
                    Console.Clear();
                    DisplayList();
                    GetBackToMenu();
                }

                Console.Clear();
                Console.WriteLine("Current vehicle's information:\n" +
                       $"{i + 1}. Model: {vehicleList[i].name} | Type: {vehicleList[i].type}\n" +
                       $"Engine power: {vehicleList[i].engine.Power} horsepower | E.volume: {vehicleList[i].engine.Volume}L | E.type: {vehicleList[i].engine.Type} | E.serial#: {vehicleList[i].engine.SerialNumber}\n" +
                       $"Number of wheels: {vehicleList[i].chassis.WheelsNumber} | Chassis VIN: {vehicleList[i].chassis.VINumber} | Permissible load: {vehicleList[i].chassis.PermissibleLoad}KG\n" +
                       $"Transmission type: {vehicleList[i].transmission.Type} | Number of gears: {vehicleList[i].transmission.NumberOfGears} | T.manufacturer: {vehicleList[i].transmission.Manufacturer}\n" +
                       $"----------------------------------------------------------------------\n");

                vehicleList[i].name = bufferName;
                vehicleList[i].type = bufferVehicleType;
                vehicleList[i].engine.Power = bufferEnginePower;
                vehicleList[i].engine.Volume = bufferEngineVolume;
                vehicleList[i].engine.Type = bufferEngineType;
                vehicleList[i].engine.SerialNumber = bufferEngineSerial;
                vehicleList[i].chassis.WheelsNumber = bufferNumberOfWheels;
                vehicleList[i].chassis.VINumber = bufferVIN;
                vehicleList[i].chassis.PermissibleLoad = bufferLoadCapacity;
                vehicleList[i].transmission.Type = bufferTransmissionType;
                vehicleList[i].transmission.NumberOfGears = bufferNumberOfGears;
                vehicleList[i].transmission.Manufacturer = bufferTransmissionManufacturer;

                Console.WriteLine("Updated information:\n" +
                   $"{i + 1}. Model: {vehicleList[i].name} | Type: {vehicleList[i].type}\n" +
                   $"Engine power: {vehicleList[i].engine.Power} horsepower | E.volume: {vehicleList[i].engine.Volume}L | E.type: {vehicleList[i].engine.Type} | E.serial#: {vehicleList[i].engine.SerialNumber}\n" +
                   $"Number of wheels: {vehicleList[i].chassis.WheelsNumber} | Chassis VIN: {vehicleList[i].chassis.VINumber} | Permissible load: {vehicleList[i].chassis.PermissibleLoad}KG\n" +
                   $"Transmission type: {vehicleList[i].transmission.Type} | Number of gears: {vehicleList[i].transmission.NumberOfGears} | T.manufacturer: {vehicleList[i].transmission.Manufacturer}\n" +
                   $"----------------------------------------------------------------------\n");

                do
                {
                    Console.WriteLine("Confirm changes? Y/N");

                    var input = Console.ReadLine();
                    response = input?.ToLower();
                    if (response == "y" || response == "n")
                    {
                        break;
                    }
                } while (true);

                if (response == "y")
                {
                    Console.Clear();
                    SaveCurrentData();
                    LoadList();
                    DisplayList();
                    Console.WriteLine("\nVehicle has been successfully updated!\n");
                    GetBackToMenu();
                }
                else
                {
                    Console.Clear();
                    DisplayList();
                    GetBackToMenu();
                }
            }
            catch
            {
                DisplayList();
                Console.WriteLine("Attempt to update failed. Please try again.\n");
                GetBackToMenu();
            }
        }

        public static void RemoveVehicle()
        {
            try
            {
                Console.Clear();
                DisplayList();
                uint idInput;

                Console.WriteLine("Please enter ID of the vehicle you want to delete:");
                while (!uint.TryParse(Console.ReadLine(), out idInput) || idInput == 0)
                {
                    Console.WriteLine("Please make sure that the entered value is a number and it is greater than zero.");
                }

                Console.Clear();
                string response;
                do
                {
                    int i = (int)idInput - 1;
                    Console.WriteLine(
                       $"{i + 1}. Model: {vehicleList[i].name} | Type: {vehicleList[i].type}\n" +
                       $"Engine power: {vehicleList[i].engine.Power} horsepower | E.volume: {vehicleList[i].engine.Volume}L | E.type: {vehicleList[i].engine.Type} | E.serial#: {vehicleList[i].engine.SerialNumber}\n" +
                       $"Number of wheels: {vehicleList[i].chassis.WheelsNumber} | Chassis VIN: {vehicleList[i].chassis.VINumber} | Permissible load: {vehicleList[i].chassis.PermissibleLoad}KG\n" +
                       $"Transmission type: {vehicleList[i].transmission.Type} | Number of gears: {vehicleList[i].transmission.NumberOfGears} | T.manufacturer: {vehicleList[i].transmission.Manufacturer}\n" +
                       $"\nAre you sure that you want to delete this vehicle? Y/N");

                    var input = Console.ReadLine();
                    response = input?.ToLower();
                    if (response == "y" || response == "n")
                    {
                        break;
                    }
                } while (true);

                if (response == "y")
                {
                    vehicleList.RemoveAt((int)idInput - 1);
                    Console.Clear();
                    SaveCurrentData();
                    LoadList();
                    DisplayList();
                    Console.WriteLine("\nVehicle has been successfully removed from the list!\n");
                    GetBackToMenu();
                }
                else
                {
                    Console.Clear();
                    DisplayList();
                    GetBackToMenu();
                }
            }
            catch
            {
                Console.WriteLine("The chosen ID is not found. Please try again.");
                DisplayList();
                GetBackToMenu();
            }
        }            
    }
}
