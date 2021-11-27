using FountainOfObjects.GameConrol;
using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.PlayerControl
{
    internal class Player
    {

        public int numberOfArrows { get; set; } 
        public Room currentRoom { get; set; }
        public void playTurn(List<Room> rooms, FountainOfObjects fountain, List<Room> amarokRooms)
        {
            if (amarokRooms.Count > 0 && numberOfArrows > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("It seems that you are in range to shoot an amarok! You have " + numberOfArrows + ".");
                Console.ResetColor();
            }
            if (currentRoom.displayActions(fountain) != "None")
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                Console.WriteLine(currentRoom.displayActions(fountain));
                Console.ResetColor();
            }
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            string playerIntput = Console.ReadLine().ToLower();
            Console.Clear();
            if (playerIntput.Contains("shoot"))
            {
                Room roomWithAmarok = amarokRooms[0];
                removeAmarokRoom(roomWithAmarok, rooms);
                Console.Clear();
                Console.WriteLine("Amarok has been eliminated.");
            }
            else if (playerIntput.Contains("move"))
            {
                if (playerIntput.Contains("north"))
                {
                    moveToNewRoom("north", rooms);
                } else if (playerIntput.Contains("south"))
                {
                    moveToNewRoom("south", rooms);
                } else if (playerIntput.Contains("east"))
                {
                    moveToNewRoom("east", rooms);
                } else if (playerIntput.Contains("west"))
                {
                    moveToNewRoom("west", rooms);
                } else
                {
                    Console.WriteLine("Undefined direction given.");
                }
            }
            else
            {
                currentRoom.action(fountain);
            }
        }


        public void moveToNewRoom(string playerDirectionChoice, List<Room> rooms)
        {
            Room newCurrentRoom = null;
            switch (playerDirectionChoice)
            {
                case "north":
                    newCurrentRoom = rooms.Find(r => r.yCoordinate == currentRoom.yCoordinate + 1 && r.xCoordinate == currentRoom.xCoordinate);
                    break;
                case "south":
                    newCurrentRoom = rooms.Find(r => r.yCoordinate == currentRoom.yCoordinate - 1 && r.xCoordinate == currentRoom.xCoordinate);
                    break;
                case "east":
                    newCurrentRoom = rooms.Find(r => r.xCoordinate == currentRoom.xCoordinate + 1 && r.yCoordinate == currentRoom.yCoordinate);
                    break;
                case "west":
                    newCurrentRoom = rooms.Find(r => r.xCoordinate == currentRoom.xCoordinate - 1 && r.yCoordinate == currentRoom.yCoordinate);
                    break;
                default:
                    Console.WriteLine("Undefined direction given");
                    break;
                    
            }

            if (newCurrentRoom != null)
            {
                currentRoom = newCurrentRoom;
            } else
            {
                Console.WriteLine("You can't go that way, silly!");
                Console.WriteLine("Which direction would you like to move?");
                string newPlayerDirection = Console.ReadLine();
                moveToNewRoom(newPlayerDirection, rooms);
            }

            checkForTraps(currentRoom, rooms);
        }

        public void removeAmarokRoom(Room roomWithAmarok, List<Room> rooms)
        {
            int amarokIndex = rooms.IndexOf(roomWithAmarok);
            int x = roomWithAmarok.xCoordinate;
            int y = roomWithAmarok.yCoordinate;
            Room newRoom = new Room();
            newRoom.xCoordinate = x;
            newRoom.yCoordinate = y;
            rooms[amarokIndex] = newRoom;
            numberOfArrows--;
            
        }

        public void checkForTraps(Room playerRoom, List<Room> rooms)
        {
            if (currentRoom.getRoomType() == "Pit")
            {
                Pit pit = new Pit();
                pit.deathByPit();
            } else if(playerRoom.getRoomType() == "Maelstrom")
            {
                Random r = new Random();
                int newRoomIndex = r.Next(0, rooms.Count);
                currentRoom = rooms[newRoomIndex];
                if (currentRoom.getRoomType() == "Pit")
                {
                    Pit pit = new Pit();
                    pit.deathByPit();
                }
            } else if (playerRoom.getRoomType() == "Amarok")
            {
                Amarok amarok = new();
                amarok.deathByAmarok();
            }
        }
    }
}
