using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public abstract class Vehicle
    {
        public abstract string VehicleName { get; set; }
        public abstract Engine VehicleEngine { get; set; }
        public abstract Chassis VehicleChassis { get; set; }
        public abstract Transmission VehicleTransmission { get; set; }

        public abstract void InformationOutput();
    }
}
