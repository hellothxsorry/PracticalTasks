using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks.VehicleParts
{
    public class Chassis
    {
        public uint WheelsNumber;
        public string VINumber;
        public double PermissibleLoad;

        public Chassis(uint wheelsNumber, string vINumber, double permissibleLoad)
        {
            WheelsNumber = wheelsNumber;
            VINumber = vINumber;
            PermissibleLoad = permissibleLoad;
        }
    }
}
