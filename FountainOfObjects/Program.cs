using FountainOfObjects.GameConrol;
using FountainOfObjects.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;

 
namespace FountainOfObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunGame runGame = new RunGame();
            runGame.startGame();
            /*
            */
        }

        public class Player
        {
            public Room currentRoom { get; set; }

        }

    }
}
