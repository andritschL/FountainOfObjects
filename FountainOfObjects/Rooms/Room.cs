using FountainOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FountainOfObjects.Program;

namespace FountainOfObjects.Rooms
{
    internal class Room : ICoordinate
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }
        bool playerInRoom { get; set; }

        public virtual string getRoomSound()
        {
            string sound = "all is quiet";
            return sound;
        }

        public virtual string getRoomSmell()
        {
            string smell = "no smell";
            return smell;
        }

        public virtual string getRoomSight()
        {
            string sight = "can't see a thing";
            return sight;
        }

    }
}
