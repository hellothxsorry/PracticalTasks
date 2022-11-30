using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public class Chassis
    {
        public int WheelsNumber;
        public string VINumber;
        public double PermissibleLoad;

        public Chassis(int wheelsNumber, string vINumber, double permissibleLoad)
        {
            WheelsNumber = wheelsNumber;
            VINumber = vINumber;
            PermissibleLoad = permissibleLoad;
        }
    }
}
