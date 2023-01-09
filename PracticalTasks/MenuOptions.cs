using PracticalTasks.VehicleParts;

namespace PracticalTasks
{
    public class MenuOptions
    {
        private VehicleList vehicleList;
        private string bufferName;
        private VehicleTypes bufferVehicleType;
        private uint bufferEnginePower;
        private double bufferEngineVolume;
        private string bufferEngineType;
        private string bufferEngineSerial;
        private uint bufferNumberOfWheels;
        private string bufferVIN;
        private double bufferLoadCapacity;
        private string bufferTransmissionType;
        private uint bufferNumberOfGears;
        private string bufferTransmissionManufacturer;

        public MenuOptions (VehicleList vehicleList)
        {
            this.vehicleList = vehicleList;
        }

        public void FilterList()
        {
            Console.Clear();
            vehicleList.ReloadData();
            Console.WriteLine("1. HIDE VEHICLES WITH ENGINE VOLUME LESS THAN 1.5L\n" +
                "2. SHOW ONLY HEAVY VEHICLES\n3. SHOW ONLY MANUAL TRANSMISSIONS\n4. SHOW ONLY AUTOMATIC TRANSMISSIONS\n5. SHOW ONLY CVT TRANSMISSIONS");

            uint action;
            while (!uint.TryParse(Console.ReadLine(), out action) || action == 0 || action > 5)
            {
                Console.WriteLine("Please choose the preferable filter by typing a number from 1 to 5.");
            }

            IEnumerable<Vehicle> bufferVehicleList;
            var engineCapacity = vehicleList.GetActualList().Where(x => x.engine.Volume > 1.5).Select(x => x);
            var allHeavy = vehicleList.GetActualList().Where(x => x.type == VehicleTypes.Truck || x.type == VehicleTypes.Bus).Select(x => x);
            var transmissionManual = vehicleList.GetActualList().Where(x => x.transmission.Type == "Manual").Select(x => x);
            var transmissionAutomatic = vehicleList.GetActualList().Where(x => x.transmission.Type == "Automatic").Select(x => x);
            var transmissionCvt = vehicleList.GetActualList().Where(x => x.transmission.Type == "CVT").Select(x => x);

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
                        ShowFullInfo(i);
                        if (i == bufferVehicleList.Count() - 1)
                        {
                            Console.Write("---------- ---------- ---------- ---------- ---------- ---------- ----------\n");
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("\nFiltering failed.\n");
            }
        }

        public void CollectDataForVehicle()
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

        public void CreateNewVehicle()
        {
            Console.Clear();
            string response;
            do
            {
                Console.WriteLine($"Model: {bufferName} | Type: {bufferVehicleType}\n" +
                $"Engine power: {bufferEnginePower} horsepower | E.volume: {bufferEngineVolume}L | " +
                $"E.type: {bufferEngineType} | E.serial#: {bufferEngineSerial}\n" +
                $"Number of wheels: {bufferNumberOfWheels} | Chassis VIN: {bufferVIN} | " +
                $"Permissible load: {bufferLoadCapacity}KG\n" +
                $"Transmission type: {bufferTransmissionType} | Number of gears: {bufferNumberOfGears} | " +
                $"T.manufacturer: {bufferTransmissionManufacturer}\n" +
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
                }

                try
                {
                    vehicleList.AddVehicle(newVehicle);
                }
                catch
                {
                    Console.WriteLine("Attempt to add a new vehicle failed. Please try again.");
                }

                Console.Clear();
                vehicleList.SaveXMLFile();
                vehicleList.ReloadData();
                Console.WriteLine("\nNew vehicle has been successfully added to the list!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nAdding a new vehicle has been canceled.\n");
            }
            
        }

        public void UpdateVehicle()
        {
            Console.Clear();
            vehicleList.ReloadData();
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
                    ShowFullInfo(i);
                    Console.WriteLine("Are you sure that you want to update this vehicle? Y/N");

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
                    vehicleList.ReloadData();
                    return;
                }

                Console.Clear();
                Console.WriteLine("Current vehicle's information:\n");
                ShowFullInfo(i);

                vehicleList.GetActualList()[i].name = bufferName;
                vehicleList.GetActualList()[i].type = bufferVehicleType;
                vehicleList.GetActualList()[i].engine.Power = bufferEnginePower;
                vehicleList.GetActualList()[i].engine.Volume = bufferEngineVolume;
                vehicleList.GetActualList()[i].engine.Type = bufferEngineType;
                vehicleList.GetActualList()[i].engine.SerialNumber = bufferEngineSerial;
                vehicleList.GetActualList()[i].chassis.WheelsNumber = bufferNumberOfWheels;
                vehicleList.GetActualList()[i].chassis.VINumber = bufferVIN;
                vehicleList.GetActualList()[i].chassis.PermissibleLoad = bufferLoadCapacity;
                vehicleList.GetActualList()[i].transmission.Type = bufferTransmissionType;
                vehicleList.GetActualList()[i].transmission.NumberOfGears = bufferNumberOfGears;
                vehicleList.GetActualList()[i].transmission.Manufacturer = bufferTransmissionManufacturer;

                Console.WriteLine("Updated information:\n");
                ShowFullInfo(i);

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
                    vehicleList.SaveXMLFile();
                    vehicleList.ReloadData();
                    Console.WriteLine("\nVehicle has been successfully updated!\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nVehicle updating process has been cancelled.\n");
                    return;
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\nAttempt to update failed. Please try again.\n");
                return;
            }
        }

        public void RemoveVehicle()
        {
            try
            {
                Console.Clear();
                vehicleList.ReloadData();
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
                    ShowFullInfo(i);
                    Console.WriteLine("\nAre you sure that you want to delete this vehicle? Y/N");

                    var input = Console.ReadLine();
                    response = input?.ToLower();
                    if (response == "y" || response == "n")
                    {
                        break;
                    }
                } while (true);

                if (response == "y")
                {
                    vehicleList.RemoveVehicle((int)idInput - 1);
                    Console.Clear();
                    vehicleList.SaveXMLFile();
                    vehicleList.ReloadData();
                    Console.WriteLine("\nVehicle has been successfully removed from the list!\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nRemoving process has been cancelled.\n");
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("\nThe chosen ID is not found. Please try again.\n");
                return;
            }
        }

        private void ShowFullInfo(int i)
        {
            Console.WriteLine($"{i + 1}. Model: {vehicleList.GetActualList()[i].name} | " +
                   $"Type: {vehicleList.GetActualList()[i].type}\n" +
                   $"Engine power: {vehicleList.GetActualList()[i].engine.Power} horsepower | " +
                   $"E.volume: {vehicleList.GetActualList()[i].engine.Volume}L | " +
                   $"E.type: {vehicleList.GetActualList()[i].engine.Type} | " +
                   $"E.serial#: {vehicleList.GetActualList()[i].engine.SerialNumber}\n" +
                   $"Number of wheels: {vehicleList.GetActualList()[i].chassis.WheelsNumber} | " +
                   $"Chassis VIN: {vehicleList.GetActualList()[i].chassis.VINumber} | " +
                   $"Permissible load: {vehicleList.GetActualList()[i].chassis.PermissibleLoad}KG\n" +
                   $"Transmission type: {vehicleList.GetActualList()[i].transmission.Type} | " +
                   $"Number of gears: {vehicleList.GetActualList()[i].transmission.NumberOfGears} | " +
                   $"T.manufacturer: {vehicleList.GetActualList()[i].transmission.Manufacturer}\n");
        }
    }
}
