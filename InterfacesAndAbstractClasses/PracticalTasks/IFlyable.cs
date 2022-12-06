using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public interface IFlyable
    {
        bool isAnyRestriction { get; set;  }
        int speed { get; set; }
        uint startPosX { get; set; }
        uint startPosY { get; set; }
        uint startPosZ { get; set; }

        public double FlyTo(uint x, uint y, uint z);

        public double GetFlyTime(double distance);
    }
}
