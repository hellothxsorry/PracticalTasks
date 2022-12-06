using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTasks
{
    public struct Coordinate
    {
        private uint X { get; set; }
        private uint Y { get; set; }
        private uint Z { get; set; }

        public void SetCurrentRandomPosition(IFlyable flyingObj)
        {
            Random rng = new Random();
            X = (uint)rng.Next(0, 100);
            Y = (uint)rng.Next(0, 100);
            Z = (uint)rng.Next(0, 100);
            flyingObj.startPosX = X;
            flyingObj.startPosY = Y;
            flyingObj.startPosZ = Z;
        }
    }
}
