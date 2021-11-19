using FountainOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.Rooms
{
    internal class Maelstrom : Room, ICoordinate
    {
        new int xCoordinate = 0;
        new int yCoordinate = 0;
        string roomType = "maelstrom";

        public override string getRoomSound()
        {
            string sound = "rushing water? or wind? or both?";
            return sound;
        }

        public override string getRoomSmell()
        {
            string smell = "smells a bit moist...";
            return smell;
        }

        public override string getRoomSight()
        {
            string sight = "Can't see a thing";
            return sight;
        }

        public override string getRoomType()
        {
            return "Maelstrom";
        }

        public void maelstromShuffle()
        {

        }
    }
}
