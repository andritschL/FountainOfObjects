using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.GameConrol
{
    internal class GameGrid
    {
        public List<Room> createGameSpaces()
        {
            List<Room> gridSpots = new List<Room>();
            int[] x = new int[4] { 0, 1, 2, 3 };
            int[] y = new int[4] { 0, 1, 2, 3 };
            foreach (int xspot in x)
            {
                foreach (int ySPot in y)
                {
                    if (xspot == 0 && ySPot == 0)
                    {
                        CavernEntrance cavernEntrance = new CavernEntrance();
                        gridSpots.Add(cavernEntrance);
                    }
                    else if (xspot == 0 && ySPot == 2)
                    {
                        FountainOfObjects fountainOfObjects = new FountainOfObjects();
                        fountainOfObjects.xCoordinate = 0;
                        fountainOfObjects.yCoordinate = 2;
                        gridSpots.Add(fountainOfObjects);
                    } else
                    {
                        Room room = new Room();
                        room.xCoordinate = xspot;
                        room.yCoordinate = ySPot;
                        gridSpots.Add(room);
                    }
                }
            }
            return gridSpots;
        }

        // Finish after gameplay is developed.  Can I dynamically add a spot to display where the player is?
        public void displayGameGrid(List<Room> rooms, Room playerLocation)
        {
            string gameSpot = "[```]";
            string playerSpot = "[ X ]";
            int counter = 1;
            foreach (Room room in rooms)
            {
                if(room.xCoordinate == playerLocation.xCoordinate && room.yCoordinate == playerLocation.yCoordinate && counter % 4 == 0)
                {
                    Console.WriteLine(playerSpot);
                } else if (room.xCoordinate == playerLocation.xCoordinate && room.yCoordinate == playerLocation.yCoordinate)
                {
                    Console.Write(playerSpot);
                } else if (counter % 4 == 0)
                {
                    Console.WriteLine(gameSpot);
                } else
                {
                    Console.Write(gameSpot);
                }
                counter++;
            } 
        }

    }
}
