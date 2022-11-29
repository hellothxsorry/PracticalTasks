using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public class Airplane : IFlyable
    {
        public bool isAnyRestriction { get; set; }
        public int speed { get; set; } = 200;
        public float startPosX { get; set; }
        public float startPosY { get; set; }
        public float startPosZ { get; set; }

        public double FlyTo(float x, float y, float z)
        {
            double distance = Math.Pow((Math.Pow(x - startPosX, 2) + Math.Pow(y - startPosY, 2) +
                Math.Pow(z - startPosZ, 2) * 1.0), 0.5);

            if (distance > 15000)
            {
                Console.WriteLine("The distance between starting and destination positions is too large: " +
                    "the airplane is able to cover only 15,000 km. Please try again with other destination coordinates.");
                isAnyRestriction = true;
            }       
            else { isAnyRestriction = false; }

            return distance;
        }

        public double GetFlyTime(double distance)
        {
            int speedBoostNumber = (int)(distance / 10);

            double flightTime = 0;

            if (speedBoostNumber >= 1)
            {
                for (int j = speed + 10, k = 0; k < speedBoostNumber; j += 10, k++)
                {
                    if (j > 1000)
                    {
                        j = 1000;
                    }

                    speed = j;
                    flightTime += (double)10 / (double)j;
                }

                distance -= speedBoostNumber * 10;
            }            

            flightTime += distance / speed;
            return flightTime;
        }
    }
}
