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
            GameGrid grid = new GameGrid();
            // populate rooms list with Rooms.  Rooms are populated with coordinates and all aspects of room type
            List<Room> rooms = grid.createGameSpaces();
            Player player = new Player();
            GamePlay gamePlay = new GamePlay();
            player.currentRoom = rooms[0];
            Room currentRoom = player.currentRoom;
            List<Room> adRooms = gamePlay.getAdjacentRooms(rooms, currentRoom);
            gamePlay.displayAdjacentRooms(adRooms, currentRoom);
        }

        public class Player
        {
            public Room currentRoom { get; set; }

        }

        public class GameGrid
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
                        } else if (xspot == 0 && ySPot == 2)
                        {
                            FountainOfObjects fountainOfObjects = new FountainOfObjects();
                            gridSpots.Add(fountainOfObjects);
                        }

                        Room room = new Room();
                        room.xCoordinate = xspot;
                        room.yCoordinate = ySPot;
                        gridSpots.Add(room);
                    }   
                }
                return gridSpots;
            }

            // Finish after gameplay is developed.  Can I dynamically add a spot to display where the player is?
            public void displayGameGrid(List<Room> grid, Room playerLocation)
            {
                int counter = 1;
                for(int i = 0; i < grid.Count; i++)
                {
                    Console.WriteLine("|___|");
                }
            }
        }

        public class GamePlay
        {
            public List<Room> getAdjacentRooms(List<Room> rooms, Room playerRoom)
            {
                List<Room> adjacentRooms = new List<Room>();
                foreach (Room room in rooms)
                {
                    if (room.xCoordinate == playerRoom.xCoordinate + 1 && room.yCoordinate == playerRoom.yCoordinate)
                    {
                        adjacentRooms.Add(room);
                        Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                    } else if (room.xCoordinate == playerRoom.xCoordinate - 1 && room.yCoordinate == playerRoom.yCoordinate)
                    {
                        adjacentRooms.Add(room);
                        Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                    } else if (room.yCoordinate == playerRoom.yCoordinate + 1 && room.xCoordinate == playerRoom.xCoordinate)
                    {
                        adjacentRooms.Add(room);
                        Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                    } else if (room.yCoordinate == playerRoom.yCoordinate - 1 && room.xCoordinate == playerRoom.xCoordinate)
                    {
                        adjacentRooms.Add(room);
                        Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                    }
                }
                return adjacentRooms;
            }

            public void displayAdjacentRooms(List<Room> adjacentRooms, Room currentRoom)
            {
                foreach (Room room in adjacentRooms)
                {
                    string sound = room.getRoomSound();
                    string smell = room.getRoomSmell();
                    string direction = ""; 
                    if (room.xCoordinate == currentRoom.xCoordinate + 1)
                    {
                        direction = "east";
                    } else if (room.xCoordinate == currentRoom.xCoordinate - 1)
                    {
                        direction = "west";
                    } else if (room.yCoordinate == currentRoom.yCoordinate + 1)
                    {
                        direction = "north";
                    } else if (room.yCoordinate == currentRoom.xCoordinate - 1)
                    {
                        direction = "south";
                    }

                    Console.WriteLine("Room to the " + direction + ": " + sound + " :: " + smell);
                }
            }
        }
    }
}
