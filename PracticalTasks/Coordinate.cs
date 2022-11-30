using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public struct Coordinate
    {
        private double X { get; set; }
        private double Y { get; set; }
        private double Z { get; set; }

        public void CurrentPos(IFlyable flyingObj)
        {
            Random rng = new Random();
            X = (rng.NextDouble() * 100);
            flyingObj.startPosX = Convert.ToSingle(X);
            flyingObj.startPosX = (float)System.Math.Round(flyingObj.startPosX, 2);
            Y = (rng.NextDouble() * 100);
            flyingObj.startPosY = Convert.ToSingle(Y);
            flyingObj.startPosY = (float)System.Math.Round(flyingObj.startPosY, 2);
            Z = (rng.NextDouble() * 100);
            flyingObj.startPosZ = Convert.ToSingle(Z);
            flyingObj.startPosZ = (float)System.Math.Round(flyingObj.startPosZ, 2);
        }
    }
}
