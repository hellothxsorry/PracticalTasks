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
        float startPosX { get; set; }
        float startPosY { get; set; }
        float startPosZ { get; set; }

        double FlyTo(float x, float y, float z);

        double GetFlyTime(double distance);
    }
}
