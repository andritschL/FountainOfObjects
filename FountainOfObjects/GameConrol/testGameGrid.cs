using FountainOfObjects.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FountainOfObjects.GameConrol
{
    internal class testGameGrid
    {
        /*
        public List<Room> createGameSpaces(FountainOfObjects fountainRoom, CavernEntrance cavernRoom, string difficulty)
        {


            List<Room> gridSpots = new List<Room>();
            int[] x = getGameGridArray(difficulty);
            int[] y = x;
            gridSpots[0] = cavernRoom;
            int[] fooRoomCoordinate = getFountainIndex(difficulty);
            //gridSpots[fooRoomIndex] = fountainRoom;
            List<int[]> pits = new();
            pits = getPitIndexes(difficulty);
            foreach (int xspot in x)
            {
                foreach (int yspot in y)
                {
                    if (xspot == 0 && yspot == 0)
                    {
                        gridSpots.Add(cavernRoom);
                    } else if (xspot == fooRoomCoordinate[0] && yspot == fooRoomCoordinate[1])
                    {
                        fountainRoom.isActivated = false;
                        fountainRoom.xCoordinate = fooRoomCoordinate[0];
                        fountainRoom.yCoordinate = fooRoomCoordinate[1];
                        gridSpots.Add(fountainRoom);
                    }
                    foreach (int[] pitSpot in pits)
                    {
                        if (pitSpot[0] == xspot && pitSpot[1] == yspot)
                        {
                            Pit pit = new Pit();
                            pit.xCoordinate = xspot;
                            pit.yCoordinate = yspot;
                            gridSpots.Add(pit);
                        }
                    }
                }
            }
            
            // Add pits 
            // Add maelstroms
            // Add amaroks
            // Fill in empty Rooms

            return gridSpots;
         }

        public int[] getFountainIndex(string difficulty)
        {
            Random spot = new();
            int[] coordinate = new int[2];
            if (difficulty == "difficult")
            {
                coordinate[0] = spot.Next(1, 11);
                coordinate[1] = spot.Next(1, 11);
                return coordinate;
            } else if (difficulty == "intermediate")
            {
                coordinate[0] = spot.Next(1, 7);
                coordinate[1] = spot.Next(1, 7);
                return coordinate;
            } else
            {
                coordinate[0] = spot.Next(1, 3);
                coordinate[1] = spot.Next(1, 3);
                return coordinate;
            }
        }

        public List<int[]> getPitIndexes(string difficulty)
        {
            List<int[]> pitpoints = new();
            int[] coordinate = new int[2];
            Random spot = new();

            int counter = 0;
            if (difficulty == "hard")
            {
                counter = 9;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 11);
                    coordinate[1] = spot.Next(1, 11);
                    pitpoints.Add(coordinate);
                }
            } else if (difficulty == "intermediate")
            {
                counter = 5;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 7);
                    coordinate[1] = spot.Next(1, 7);
                    pitpoints.Add(coordinate);
                }
            }
            else
            {
                counter = 2;
                for (int i = 0; i < counter; i++)
                {
                    coordinate[0] = spot.Next(1, 3);
                    coordinate[1] = spot.Next(1, 3);
                    pitpoints.Add(coordinate);
                }
            }
            return pitpoints;
        }
    
        */
    }
}
