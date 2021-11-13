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
    internal class CavernEntrance : Room, ICoordinate
    {
        new int xCoordinate = 0;
        new int yCoordinate = 0;

        public override string getRoomSound()
        {
            string sound = "birds?";
            return sound;
        }
        public override string getRoomSmell()
        {
            string smell = "Smells like fresh air";
            return smell;
        }
        public override string getRoomSight()
        {
            string sight = "There is light!";
            return sight;
        }
    }
}
