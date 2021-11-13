using FountainOfObjects.Interfaces;
using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FountainOfObjects.Program;

namespace FountainOfObjects
{
    internal class FountainOfObjects : Room, ICoordinate
    {
        public bool isActivated { get; set; }
        new int xCoordinate = 0;
        new int yCoordinate = 2;

        public override string getRoomSound()
        {
            string sound;
            if (isActivated)
            {
                sound = "rushing water";
            }
            else
            {
                sound = "dripping water";
            }
            return sound;
        }

        public override string getRoomSmell()
        {
            string roomSmell = "moist";
            return roomSmell;
        }

    }
}
