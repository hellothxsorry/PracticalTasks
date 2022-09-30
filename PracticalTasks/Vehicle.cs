using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    class Vehicle
    {
        public string VehicleName;

        public Vehicle(string name, Engine engine, Chassis chassis, Transmission transmission)
        {
            VehicleName = name;
            Console.WriteLine("Type of vehicle: " + name + "\n" + "Engine power: " + engine.Power + " horsepower" + " | " +
                "Engine volume: " + engine.Volume + "L" + " | " + "Engine type: " + engine.Type + " | " +
                "Engine serial number: " + engine.SerialNumber + "\n" + "Number of wheels: " + chassis.WheelsNumber +
                " | " + "The VIN (Vehicle Identification Number): " + chassis.VINumber + " | " +
                "Loading capacity: " + chassis.PermissibleLoad + " kg" + "\n" + "Transmission type: " + transmission.Type +
                " | " + "Number of gears: " + transmission.NumberOfGears + " | " + "Transmission manufacturer: " +
                transmission.Manufacturer + "\n");
        }
    }
}
