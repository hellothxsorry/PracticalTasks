using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    internal class Drone : IFlyable
    {
        public bool isAnyRestriction { get; set; }
        public int speed { get; set; } = 200;
        public float startPosX { get; set; }
        public float startPosY { get; set; }
        public float startPosZ { get; set; }

        double distance;
        double flightTime;
                
        //1 min hovering every 10 min
        //Travel time = distance / speed
        //Additional time = travel time / 10
        //Time of flight = distance / speed + additional time 
        public double FlyTo(float x, float y, float z)
        {
            double distance = Math.Pow((Math.Pow(x - startPosX, 2) + Math.Pow(y - startPosY, 2) +
                Math.Pow(z - startPosZ, 2) * 1.0), 0.5);

            //Limit the maximum distance: the drone is capable to cover up to 200 km
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
