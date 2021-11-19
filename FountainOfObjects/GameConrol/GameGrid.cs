﻿using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.GameConrol
{
    internal class GameGrid
    {
        /*
        public List<Room> createGameSpaces(FountainOfObjects fountainRoom, CavernEntrance cavern, string difficulty)
        {
            List<Room> gridSpots = new List<Room>();
            int[] x = getGameGridArray(difficulty);
            int[] y = x;
            foreach (int xspot in x)
            {
                int randomMaelstrom;
                Random m = new Random();
                int randomPit;
                Random r = new Random();
                if (difficulty == "hard")
                {
                    randomMaelstrom = m.Next(0, 12);
                    randomPit = r.Next(0, 12);
                } else if (difficulty == "intermediate")
                {
                    randomMaelstrom = m.Next(0, 8);
                    randomPit = r.Next(0, 8);
                } else
                {
                    randomMaelstrom = m.Next(0, 4);
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

                    } else if (yspot == randomMaelstrom)
                    {
                        Maelstrom maelstrom = new();
                        maelstrom.xCoordinate = xspot;
                        maelstrom.yCoordinate = yspot;
                        gridSpots.Add(maelstrom);
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
        */
        public List<Room> createGameSpaces(FountainOfObjects fountainRoom, CavernEntrance cavernRoom, string difficulty)
        {


            List<Room> gridSpots = new List<Room>();
            int[] x = getGameGridArray(difficulty);
            int[] y = x;
            int[] fooRoomCoordinate = getFountainIndex(difficulty);
            //gridSpots[fooRoomIndex] = fountainRoom;
            List<int[]> pits = new();
            pits = getPitIndexes(difficulty);
            
            foreach (int xspot in x)
            {
                foreach (int yspot in y)
                {
                    int[] searchForPits = pits.Find(r => r[0] == xspot && r[1] == yspot);
                    if (xspot == 0 && yspot == 0)
                    {
                        gridSpots.Add(cavernRoom);
                    }
                    else if (xspot == fooRoomCoordinate[0] && yspot == fooRoomCoordinate[1])
                    {
                        fountainRoom.isActivated = false;
                        fountainRoom.xCoordinate = fooRoomCoordinate[0];
                        fountainRoom.yCoordinate = fooRoomCoordinate[1];
                        gridSpots.Add(fountainRoom);
                    } else if (searchForPits != null)
                    {
                        Pit pit = new Pit();
                        pit.xCoordinate = xspot;
                        pit.yCoordinate = yspot;
                        gridSpots.Add(pit);
                    } else 
                    {
                        Room room = new();
                        room.xCoordinate = xspot;
                        room.yCoordinate = yspot;
                        gridSpots.Add(room);
                    }
                }
            }

            // Add pits 
            // Add maelstroms
            // Add amaroks
            // Fill in empty Rooms

            return gridSpots;
        }

        public int[] getFountainIndex(string difficulty)
        {
            Random spot = new();
            int[] coordinate = new int[2];
            if (difficulty == "difficult")
            {
                coordinate[0] = spot.Next(1, 11);
                coordinate[1] = spot.Next(1, 11);
                return coordinate;
            }
            else if (difficulty == "intermediate")
            {
                coordinate[0] = spot.Next(1, 7);
                coordinate[1] = spot.Next(1, 7);
                return coordinate;
            }
            else
            {
                coordinate[0] = spot.Next(1, 3);
                coordinate[1] = spot.Next(1, 3);
                return coordinate;
            }
        }

        public List<int[]> getPitIndexes(string difficulty)
        {
            List<int[]> pitpoints = new();
            int[] coordinate = new int[2];
            Random spot = new();

            int counter = 0;
            if (difficulty == "hard")
            {
                counter = 9;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 11);
                    coordinate[1] = spot.Next(1, 11);
                    pitpoints.Add(coordinate);
                }
            }
            else if (difficulty == "intermediate")
            {
                counter = 5;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 7);
                    coordinate[1] = spot.Next(1, 7);
                    pitpoints.Add(coordinate);
                }
            }
            else
            {
                counter = 2;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 3);
                    coordinate[1] = spot.Next(1, 3);
                    pitpoints.Add(coordinate);
                }
            }
            return pitpoints;
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
