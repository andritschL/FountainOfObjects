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
            double totalTime = latestTime.Subtract(startTime).TotalMinutes;
            
             Console.WriteLine("Game Time: " + totalTime);
        }
    }
}
