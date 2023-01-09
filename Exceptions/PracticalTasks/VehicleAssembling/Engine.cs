using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.VehicleParts
{
    public class Engine
    {
        public uint Power;
        public double Volume;
        public string Type;
        public string SerialNumber;

        public Engine(uint power, double volume, string type, string serial)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serial;
        }
    }
}
