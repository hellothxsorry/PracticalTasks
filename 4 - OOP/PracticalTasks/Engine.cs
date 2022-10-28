using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    internal class Engine
    {
        public int Power;
        public double Volume;
        public string Type;
        public string SerialNumber;

        public Engine(int power, double volume, string type, string serial)
        {
            Power = power;
            Volume = volume;
            Type = type;
            SerialNumber = serial;
        }        
    }
}
