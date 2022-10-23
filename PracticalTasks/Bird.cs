using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    internal class Bird: IFlyable
    {
        public bool isAnyRestriction { get; set; }
        public int speed { get; set; }
        public float startPosX { get; set; }
        public float startPosY { get; set; }
        public float startPosZ { get; set; }

        public double FlyTo(float x, float y, float z)
        {
            randomSpeed();

            //Define the distance between starting 3D coords and destination coords.
            double distance = Math.Pow((Math.Pow(x - startPosX, 2) + Math.Pow(y - startPosY, 2) +
                Math.Pow(z - startPosZ, 2) * 1.0), 0.5);

            //
            if (distance > 160)
            {
                //Additional restriction to prevent the bird to fly more than 160 km without a rest.
                Console.Write($"The distance between the starting and destination positions is {String.Format("{0:0.00}", distance)} km " +
                    $"\nwhile the bird can cover not more than 160 km at once" +
                    $"\nPlease try another destination coordinates.");
                isAnyRestriction = true;
            }
            else { isAnyRestriction = false; }

            return distance;
        }

        public double GetFlyTime(double distance)
        {         
            double flightTime = distance / speed;

            if (flightTime > 6.25)
            {
                //Additional restriction to prevent the bird to fly longer than 6.25 hours at the same speed with no rest.
                Console.Write($"This time the bird's speed is {speed} km/h so the flight will take {String.Format("{0:0.0}", flightTime)} hours." +
                    $"\nUnfortunately, the bird can cover only a 6-ish hours flight." +
                    $"\nPlease try again.\n---------------\n");
            }

            return flightTime;
        }

        private void randomSpeed()
        {
            Random rng = new Random();
            //Setting a random speed for the bird in the range of 0-20 km/h
            speed = rng.Next(0, 20);

            //Restart the console app if the bird is not moving since the speed has been randomly set to zero
            if (speed == 0) 
            {
                Console.WriteLine("For some reason, the bird is not able to fly at the moment so its speed equals to zero." +
                            "\nPlease try again. Sorry for the inconvenience!\n---------------\n");
                isAnyRestriction = true; 
            }
            else { isAnyRestriction = false; }
        }
    }
}
