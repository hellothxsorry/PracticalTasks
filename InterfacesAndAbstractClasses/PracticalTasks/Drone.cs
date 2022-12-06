using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public class Drone : IFlyable
    {
        public bool isAnyRestriction { get; set; }
        public int speed { get; set; } = 200;
        public uint startPosX { get; set; }
        public uint startPosY { get; set; }
        public uint startPosZ { get; set; }

        private double flightTime;
                
        public double FlyTo(uint x, uint y, uint z)
        {
            double distance = Vector3.Distance(new Vector3(x, y, z), new Vector3(startPosX, startPosY, startPosZ));

            if (distance > 200)
            {
                Console.WriteLine("The distance between starting and destination positions is too large: " +
                    "the drone is capable to cover only 200 km. Please try again with other destination coordinates.");
                isAnyRestriction = true;
            }
            else { isAnyRestriction = false; }

            return distance;
        }

        public double GetFlyTime(double distance)
        {
            double flightTimeInMinutes = distance / speed * 60;

            int hoveringPeriods;

            if (flightTimeInMinutes < 10) { hoveringPeriods = 0; }
            else { hoveringPeriods = (int)flightTimeInMinutes / 10; }

            flightTime += distance / speed + hoveringPeriods / 60;

            return flightTime;
        }
    }
}
