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
                        fountainOfObjects.isActivated = false;
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
            List<Room> y0 = new List<Room>();
            List<Room> y1 = new List<Room>();
            List<Room> y2 = new List<Room>();
            List<Room> y3 = new List<Room>();
            // Split Array and group by Y
            foreach (Room room in rooms)
            {
                if (room.yCoordinate == 0)
                {
                    y0.Add(room);
                } else if (room.yCoordinate == 1)
                {
                    y1.Add(room);
                } else if (room.yCoordinate == 2)
                {
                    y2.Add(room);
                } else if (room.yCoordinate == 3)
                {
                    y3.Add(room);
                }
            }
            getDisplay(y3, playerLocation);
            getDisplay(y2, playerLocation);
            getDisplay(y1, playerLocation);
            getDisplay(y0, playerLocation);
            Console.WriteLine();
        }

        public void getDisplay(List<Room> roomsByYCoordinate, Room playerLocation)
        {
            string row = null;
            string gameSpot = "[```]";
            string playerSpot = "[ X ]";
            foreach (Room room in roomsByYCoordinate)
            {
                if (room.xCoordinate == playerLocation.xCoordinate && room.yCoordinate == playerLocation.yCoordinate)
                {
                    row += playerSpot;
                } else {
                    row += gameSpot;
                }
            }
            Console.WriteLine(row);
        }

    }
}
