using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    class Vehicle
    {
        public string name { get; set; }
        public VehicleTypes type { get; set; }
        public Engine engine { get; set; }
        public Chassis chassis { get; set; }
        public Transmission transmission { get; set; }

        public Vehicle(string name, VehicleTypes vtype, Engine engine, Chassis chassis, Transmission transmission)
        {
            this.name = name;
            type = vtype;
            this.engine = engine;
            this.chassis = chassis;
            this.transmission = transmission;
        }
    }

    enum VehicleTypes
    {
        PassengerCar,
        Truck,
        Bus,
        Scooter
    }
}
