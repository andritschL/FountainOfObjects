using FountainOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.Rooms
{
    internal class Amarok : Room, ICoordinate
    {
        new int xCoordinate { get; set; }
        new int yCoordinate { get; set; }  

        public override string getRoomSound()
        {
            return "sounds like a sqealing animal of some kind?";
        }

        public override string getRoomSmell()
        {
            return "is that something rotting?! Gross!";
        }

        public override string getRoomSight()
        {
            return "can't see a thing";
        }

        public override string getRoomType()
        {
            return "amarok";
        }

        public override string displayActions(FountainOfObjects fountain)
        {
            return "None";
        }

        public void playerNear(Room playerLocation, int numberOfArrows)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("It seems that you are in range to shoot an amarok! You have " + numberOfArrows + ".");
            Console.ResetColor();


        }

        public void deathByAmarok()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You have been killed by an Amarok.");
            Console.WriteLine("GAME OVER");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
