using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FountainOfObjects.Program;


namespace FountainOfObjects.GameConrol
{
    internal class RunGame
    {
        public string gameDifficulty = "easy";
        public void startGame()
        {
            Console.WriteLine("Welcome to the Fountain of Objects!");
            Console.WriteLine("The Oject of this game is to navigate your player to the fountain of objects room, activate the fountain, then navigate back to the cavern entrance");
            Console.WriteLine("Choose a game difficulty to start. Hard, Intermediate, or Easy");
            gameDifficulty = Console.ReadLine();

        }
    }
}
