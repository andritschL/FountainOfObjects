using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FountainOfObjects.Program;
using FountainOfObjects.PlayerControl;


namespace FountainOfObjects.GameConrol
{
    internal class RunGame
    {   
        public string gameDifficulty = "easy";
        public bool gameOver = false;
        Player player = new Player();
        FountainOfObjects fountainOfObjects = new FountainOfObjects();
        CavernEntrance cavernEntrance = new CavernEntrance();
        Clock clock = new Clock();

        public void startGame()
        {
            Console.WriteLine("Welcome to the Fountain of Objects!");
            Console.WriteLine();
            Console.WriteLine("The Oject of this game is to navigate your player to the fountain of objects room, activate the fountain, then navigate back to the cavern entrance");
            Console.WriteLine();
            Console.WriteLine("Choose a game difficulty to start. Hard, Intermediate, or Easy");
            gameDifficulty = Console.ReadLine().ToLower();
            Console.Clear();
            Console.WriteLine("Your player is the 'X'. Each turn, the sound, smell, and visuals of the next room will be displayed to you so you know if a room is safe to enter or so you can hear the fountain.");
            Console.WriteLine("You will have the option to move in these directions: North, South, East, West.");
            Console.WriteLine("Some rooms will have other options that will be displayed to you as you're in the room.");
            Console.WriteLine("To move through the game, type 'move' followed by a direction.");
            Console.WriteLine("To do anything else in the game, just type what you'd like to do. It's not SUPER fancy, so don't get carried away.");
            Console.WriteLine("To start, enter 'begin', or 'exit' to leave the game");
            string playerStart = Console.ReadLine();

            Console.Clear();
            if (playerStart == "begin")
            {
                Console.WriteLine(clock.startTime);
                executeGame();
            } else
            {
                Environment.Exit(0);
            }
        }

        public void executeGame()
        {
            GameGrid grid = new GameGrid();
            GamePlay gamePlay = new ();
            // populate rooms list with Rooms.  Rooms are populated with coordinates and all aspects of room type
            List<Room> rooms = grid.createGameSpaces(fountainOfObjects, cavernEntrance, gameDifficulty);
            player.currentRoom = rooms[0];
            player.numberOfArrows = 3;

            while (gameOver == false)
            {
                Room currentRoom = player.currentRoom;
                clock.displayTimeInGame();
                grid.displayGameGrid(rooms, currentRoom, gameDifficulty);
                List<Room> adRooms = gamePlay.getAdjacentRooms(rooms, currentRoom);
                gamePlay.displayAdjacentRooms(adRooms, currentRoom);
                List<Room> amarokRooms = gamePlay.amarokNearby(rooms, currentRoom);
                Console.WriteLine();
                player.playTurn(rooms, fountainOfObjects, amarokRooms);
            }
        }
    }
}
