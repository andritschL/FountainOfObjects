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
        public void startGame()
        {
            Console.WriteLine("Welcome to the Fountain of Objects!");
            Console.WriteLine();
            Console.WriteLine("The Oject of this game is to navigate your player to the fountain of objects room, activate the fountain, then navigate back to the cavern entrance");
            Console.WriteLine();
            Console.WriteLine("Choose a game difficulty to start. Hard, Intermediate, or Easy");
            gameDifficulty = Console.ReadLine();
            Console.WriteLine("Your player is the 'X'. Each turn, the sound, smell, and visuals of the next room will be displayed to you so you know if a room is safe to enter or so you can hear the fountain.");
            Console.WriteLine("You will have the option to move in these directions: North, South, East, West.");
            Console.WriteLine("Some rooms will have other options that will be displayed to you as you're in the room.");
            Console.WriteLine("To start, enter 'begin', or 'exit' to leave the game");
            string playerStart = Console.ReadLine();
            if (playerStart == "begin")
            {
                executeGame();
            } else
            {
                Environment.Exit(0);
            }
        }

        public void executeGame()
        {
            while(gameOver == false)
            {
                GameGrid grid = new GameGrid();
                GamePlay gamePlay = new GamePlay();
                // populate rooms list with Rooms.  Rooms are populated with coordinates and all aspects of room type
                List<Room> rooms = grid.createGameSpaces();
                PlayerControl.Player player = new PlayerControl.Player();
                player.currentRoom = rooms[0];
                Room currentRoom = player.currentRoom;
                grid.displayGameGrid(rooms, currentRoom);
                List<Room> adRooms = gamePlay.getAdjacentRooms(rooms, currentRoom);
                gamePlay.displayAdjacentRooms(adRooms, currentRoom);
                Console.WriteLine("Which direction would you like to move?");
                string playerDirectionChoice = Console.ReadLine();

                player.moveToNewRoom(playerDirectionChoice);
            }

        }
    }
}
