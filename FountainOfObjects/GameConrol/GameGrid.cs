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
        public List<Room> createGameSpaces(FountainOfObjects fountainRoom, CavernEntrance cavern, string difficulty)
        {
            List<Room> gridSpots = new List<Room>();
            int[] x = getGameGridArray(difficulty);
            int[] y = x;
            foreach (int xspot in x)
            {
                int randomPit;
                Random r = new Random();
                if (difficulty == "hard")
                {
                    randomPit = r.Next(0, 12);
                } else if (difficulty == "intermediate")
                {
                    randomPit = r.Next(0, 8);
                } else
                {
                    randomPit = r.Next(0, 4);
                }

                foreach (int yspot in y)
                {
                    if (xspot == 0 && yspot == 0)
                    {
                        gridSpots.Add(cavern);
                    }
                    else if (xspot == 0 && yspot == 2)
                    {
                        fountainRoom.isActivated = false;
                        fountainRoom.xCoordinate = 0;
                        fountainRoom.yCoordinate = 2;
                        gridSpots.Add(fountainRoom);
                    } else if (yspot == randomPit)
                    {
                        Pit pit = new Pit();
                        pit.xCoordinate = xspot;
                        pit.yCoordinate = yspot;
                        gridSpots.Add(pit);

                    } else
                    {
                        Room room = new Room();
                        room.xCoordinate = xspot;
                        room.yCoordinate = yspot;
                        gridSpots.Add(room);
                    }

                }
            }
            return gridSpots;
        }

        public int[] getGameGridArray(string difficulty)
        {
            if (difficulty == "hard")
            {
                int[] array = new int[12] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
                return array;
            } else if (difficulty == "intermediate")
            {
                int[] array = new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 };
                return array;
            } else
            {
                int[] array = new int[4] { 0, 1, 2, 3 };
                return array;
            }
        }

        public void displayGameGrid(List<Room> rooms, Room playerLocation, string difficulty)
        {
            List<List<Room>> rows = new();
            int rowMaxValue = 4;
            if (difficulty == "hard")
            {
                rowMaxValue = 12;
            }
            
            if (difficulty == "intermediate")
            {
                rowMaxValue = 8;
            }

            int rowCounter = 0;
            while (rowCounter < rowMaxValue)
            {
                List<Room> rowRooms = rooms.FindAll(r => r.yCoordinate.Equals(rowCounter));
                rows.Add(rowRooms);
                rowCounter++;
            }
            rows.Reverse();
            foreach (List<Room> gridRow in rows)
            {
                getDisplay(gridRow, playerLocation);
            }

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
