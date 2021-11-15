﻿using FountainOfObjects.Rooms;
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

        public void playRoom(string instructions)
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
