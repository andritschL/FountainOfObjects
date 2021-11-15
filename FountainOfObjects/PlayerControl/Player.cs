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
        public Room currentRoom { get; set; }

        public void playTurn(List<Room> rooms)
        {
            string roomAction = currentRoom.displayActions();
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
                    currentRoom.action();
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

        public void playRoomAction()
        {

        }


        public void moveToNewRoom(string playerDirectionChoice, List<Room> rooms)
        {
            Room backupCurrentRoom = currentRoom;
            Room newCurrentRoom = null;
            switch (playerDirectionChoice)
            {
                case "north":
                    newCurrentRoom = rooms.Find(r => r.yCoordinate == currentRoom.yCoordinate + 1 && r.xCoordinate == currentRoom.xCoordinate);
                    currentRoom = newCurrentRoom;
                    break;
                case "south":
                    newCurrentRoom = rooms.Find(r => r.yCoordinate == currentRoom.yCoordinate - 1 && r.xCoordinate == currentRoom.xCoordinate);
                    currentRoom = newCurrentRoom;
                    break;
                case "east":
                    newCurrentRoom = rooms.Find(r => r.xCoordinate == currentRoom.xCoordinate + 1 && r.yCoordinate == currentRoom.yCoordinate);
                    currentRoom = newCurrentRoom;
                    break;
                case "west":
                    newCurrentRoom = rooms.Find(r => r.xCoordinate == currentRoom.xCoordinate - 1 && r.yCoordinate == currentRoom.yCoordinate);
                    currentRoom = newCurrentRoom;
                    break;
                default:
                    Console.WriteLine("Undefined direction given");
                    break;
                    
            }

            if (newCurrentRoom == null)
            {
                newCurrentRoom = currentRoom;
                Console.WriteLine("You cannot go in that direction.  Did you mean to go a different direction?");
                Console.WriteLine("Which direction would you like to go?");
                string newPlayerDirection = Console.ReadLine();
                moveToNewRoom(newPlayerDirection, rooms);

            }
        }
    }
}
