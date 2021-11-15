using FountainOfObjects.Rooms;
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

        public void playRoomActions(string instructions)
        {
            string roomType = currentRoom.getRoomType();
            if (roomType == "FountainOfObjects")
            {
                Console.WriteLine("You have found the Fountain of Objects! Would you like to activate it? (Yes = Activate. NO = I am a butt sandwich");
                string playerDecision = Console.ReadLine();
                if (playerDecision == "Yes")
                {
                    // I think this created a new instance of the class which will not show in the room list?
                    FountainOfObjects fountain = new FountainOfObjects();
                    fountain.isActivated = true;
                }
            } else if (roomType == "Cavern")
            {

            } else if (roomType == "Empty Room")
            {

            }

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
