﻿using FountainOfObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.Rooms
{
    internal class Pit : Room, ICoordinate
    {
        public int xCoordinate { get; set; }
        public int yCoordinate { get; set; }

        public override string getRoomSound()
        {
            string sound = "seems like there's an upward draft!";
            return sound;
        }

        public override string getRoomSmell()
        {
            string smell = "definitely smells like a basement";
            return smell;
        }

        public override string getRoomSight()
        {
            string sight = "can't see a thing";
            return sight;
        }

        public override string getRoomType()
        {
            return "Pit";
        }

        public override string displayActions(FountainOfObjects fountain)
        {
            return "None";
        }

        public void deathByPit()
        {
            Console.WriteLine("You have fallen into a pit and died.");
            Console.WriteLine("GAME OVER");
            Environment.Exit(0);
        }
    }
}
