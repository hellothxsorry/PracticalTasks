using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticalTasks.VehicleAssembling;

namespace PracticalTasks
{
    public class VehiclesManagement
    {
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

        public static void CollectDataForVehicle()
        {
            Console.WriteLine("\nPlease type a vehicle name:");
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

        public static void AddVehicle()
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
                DataHandler.SaveCurrentData();
                LoadList();
                DisplayList();
                Console.WriteLine("\nNew vehicle has been successfully added to the list!\n");
                GetBackToMenu();
            }
            else
            {
                Console.Clear();
                LoadList();
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
