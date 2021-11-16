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
        string roomType = "cavern";

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

        public override string getRoomType()
        {
            return "Cavern";
        }

        public override string displayActions(FountainOfObjects fountain)
        {
            if (fountain.isActivated)
            {
                return "Exit the cavern to win the game?";
            } else
            {
                return "None";
            }
        }

        public override void action(FountainOfObjects fountain)
        {
            if (fountain.isActivated)
            {
                Console.WriteLine("You have defeated the Fountain of Ojects!");
                Environment.Exit(0);
            }
        }

    }
}
