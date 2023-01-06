using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.VehicleParts
{
    public class Transmission
    {
        public string Type;
        public uint NumberOfGears;
        public string Manufacturer;

        public Transmission(string type, uint numberOfGears, string manufacturer)
        {
            Type = type;
            NumberOfGears = numberOfGears;
            Manufacturer = manufacturer;
        }
    }
}
