using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.GameConrol
{
    internal class Clock
    {
        public DateTime startTime = DateTime.Now;


        public void displayTimeInGame()
        {
            DateTime latestTime = DateTime.Now;
            double totalTime = latestTime.Subtract(startTime).TotalSeconds;
            int minutes = (int)(totalTime / 60) % 60;
            int seconds = (int)totalTime % 60;
            string timeToDisplay = "Game Time: " + minutes.ToString() + ":" + seconds.ToString();

            Console.WriteLine(timeToDisplay);
        }
    }
}
