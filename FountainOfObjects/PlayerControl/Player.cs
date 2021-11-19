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
        private object runGame;

        public Room currentRoom { get; set; }

        public void playTurn(List<Room> rooms, FountainOfObjects fountain)
        {
            string roomAction = currentRoom.displayActions(fountain);
            if (roomAction != "None")
            {
                Console.WriteLine("Would you like to move to a new room or " + roomAction + "?");
                Console.WriteLine("Type 'Move' or 'Action'");
                string playerChoice = Console.ReadLine();
                if (playerChoice == "Move")
                {
                    Console.WriteLine();
                    Console.WriteLine("Which direction would you like to move?");
                    Console.WriteLine();
                    string playerDirectionChoice = Console.ReadLine();
                    moveToNewRoom(playerDirectionChoice, rooms);

                } else if (playerChoice == "Action")
                {
                    currentRoom.action(fountain);
                }
            } else
            {
                Console.WriteLine();
                Console.WriteLine("Which direction would you like to move?");
                Console.WriteLine();
                string playerDirectionChoice = Console.ReadLine();
                moveToNewRoom(playerDirectionChoice, rooms);
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
            }
        }
    }
}
