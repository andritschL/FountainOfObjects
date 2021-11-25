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
        new int xCoordinate  { get; set; }
        new int yCoordinate { get; set; }
        string roomType = "Fountain of Objects";

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

        public override string getRoomType()
        {
            return "FountainOfObjects";
        }

        public override string displayActions(FountainOfObjects fountain)
        {
            if (isActivated)
            {
                return "You could turn off the fountain if you wanted, but that would be stupid. Just saying.";
            } else
            {
                return "You found the fountain of objects! Maybe you should activate it!";
            }
        }

        public override void action(FountainOfObjects fountain)
        {
            isActivated = true;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The fountain has been activiated.  Return to the cavern entrance safely!");
            Console.ResetColor();
        }



    }
}
