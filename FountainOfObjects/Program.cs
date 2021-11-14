using FountainOfObjects.GameConrol;
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
            grid.displayGameGrid(rooms, currentRoom);
            List<Room> adRooms = gamePlay.getAdjacentRooms(rooms, currentRoom);
            gamePlay.displayAdjacentRooms(adRooms, currentRoom);
        }

        public class Player
        {
            public Room currentRoom { get; set; }

        }

    }
}
