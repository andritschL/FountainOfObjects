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
            player.currentRoom = rooms[0];
          
        }

        public class Player
        {
            public Room currentRoom { get; set; }

        }

        public interface ICoordinate
        {
            public int xCoordinate { get; set; }    
            public int yCoordinate { get; set; }

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
            public bool checkIfAdjacent(List<Room> rooms, int x, int y)
            {
                switch (x)
                {
                }
            }
        }


        public class Room : ICoordinate
        {
            public int xCoordinate { get; set; }
            public int yCoordinate { get; set; }
            bool playerInRoom { get; set; }

            public virtual string getRoomSound()
            {
                string sound = "all is quiet";
                return sound;
            }

            public virtual string getRoomSmell()
            {
                string smell = "no smell";
                return smell;
            }

            public virtual string getRoomSight()
            {
                string sight = "can't see a thing";
                return sight;
            }
            
        }

        public class FountainOfObjects : Room, ICoordinate
        {
            public bool isActivated { get; set; }
            new int xCoordinate = 0;
            new int yCoordinate = 2;

           public override string getRoomSound()
            {
                string sound;
                if (isActivated)
                {
                    sound = "rushing water";
                } else
                {
                    sound = "dripping water";
                }
                return sound;
            }

            public override string getRoomSmell()
            {
                string roomSmell = "moist";
                return roomSmell;
            }
        }

        public class CavernEntrance : Room, ICoordinate
        {
            new int xCoordinate = 0;
            new int yCoordinate = 0;

            public override string getRoomSound()
            {
                string sound = "birds?";
                return sound;
            }
            public override string getRoomSmell()
            {
                string smell = "Smells like fresh air";
                return smell;
            }
            public override string getRoomSight()
            {
                string sight = "There is light!";
                return sight;
            }
        }
    }
}
