using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.GameConrol
{
    internal class GamePlay
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
                }
                else if (room.xCoordinate == playerRoom.xCoordinate - 1 && room.yCoordinate == playerRoom.yCoordinate)
                {
                    adjacentRooms.Add(room);
                    Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                }
                else if (room.yCoordinate == playerRoom.yCoordinate + 1 && room.xCoordinate == playerRoom.xCoordinate)
                {
                    adjacentRooms.Add(room);
                    Console.WriteLine("x = " + room.xCoordinate + "y = " + room.yCoordinate);
                }
                else if (room.yCoordinate == playerRoom.yCoordinate - 1 && room.xCoordinate == playerRoom.xCoordinate)
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
                }
                else if (room.xCoordinate == currentRoom.xCoordinate - 1)
                {
                    direction = "west";
                }
                else if (room.yCoordinate == currentRoom.yCoordinate + 1)
                {
                    direction = "north";
                }
                else if (room.yCoordinate == currentRoom.xCoordinate - 1)
                {
                    direction = "south";
                }

                Console.WriteLine("Room to the " + direction + ": " + sound + " :: " + smell);
            }
        }

    }
}
