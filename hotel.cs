
using System.Security.Cryptography.X509Certificates;

namespace Hotel_Management_Software;

class Hotel
//class for a specific hotel, including its name, how many guests are currently staying and a list of all the rooms
{
    public string Name;
    public int CurrentGuests;
    public static List<Room> Rooms = new List<Room>();
    //list of rooms at the hotel
    public static void AddRemoveRoom()
    //method for staff to add or remove rooms through the console
    {
        Console.WriteLine("Do you want to add or remove a room?");
        string input = Console.ReadLine()!;

        if (input.ToLower() == "a")
        {
            Console.Write("Room number: ");
            string roomNr = Console.ReadLine()!;

            Console.Write("Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Room price: ");
            double roomPrice = double.Parse(Console.ReadLine()!);

            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine()!);     

            Console.Write("Floor number: ");
            int floorNr = int.Parse(Console.ReadLine()!);

            Rooms.Add(new Room(roomNr, description, roomPrice, capacity, floorNr));
            //adds a new room with the details specified by the staff through console inputs
        }
        else if (input.ToLower() == "r")
        {
            int i = 0;
            foreach(Room r in Rooms )
            {   
                i++;
                Console.WriteLine($"{i}.  {r.RoomNr}. '{r.Description}'");
            }
            //Lists all the rooms that are available to be removed with a corresponding number starting at 1
            Console.Write("Choose room to be removed");
            int remove = int.Parse(Console.ReadLine()!);
            Rooms.RemoveAt(remove -1);
            //removes a room corresponding to the number input through the console
        }


    }

    public static void CheckIn()
    //method for staff to check in guests to a room
    {
        Console.Write("What roomnumber is getting checked into?: ");
        string roomNr = Console.ReadLine()!;
        if(Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
        //checks if a room with the roomnumber specified through the console exists
        {
            int i = Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
            //makes an integer for the index used in the list of rooms matching the roomnumber input by the staff
            if(Rooms[i].isChecked == false && Rooms[i].isBooked == true)
            //checks that the specified room is not currently checked into and that there is a booking for the room
            {
                Rooms[i].isChecked = true;
                Console.WriteLine($"Room number: {Rooms[i].RoomNr}, '{Rooms[i].Description}' has been checked into.");
                //sets the status of the room to being checked into
            }
            else if(Rooms[i].isChecked == true)
            {
                Console.WriteLine($"Error, Room number: {Rooms[i].RoomNr}, '{Rooms[i].Description}' is already checked into.");
            }
            else
            {
                Console.WriteLine($"Error, Room number: {Rooms[i].RoomNr}, '{Rooms[i].Description}' has not been booked.");
            }
        }
        else
        {
            Console.WriteLine($"Error! no room with roomnumber '{roomNr}' exists");
        }
    }

    public static void  CheckOut()
    //method for staff to check guests out of their room
    {
        Console.Write("What roomnumber is getting checked out of?: ");
        string roomNr = Console.ReadLine()!;
        if(Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
        //checks if a room with the roomnumber specified through the console exists
        {
            int i = Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
            //makes an integer for the index used in the list of rooms matching the roomnumber input by the staff
            if(Rooms[i].isChecked == true)
            //checks that the specified room is currently checked into
            {
                Rooms[i].isChecked = false;
                Rooms[i].isBooked = false;
                Console.WriteLine($"Room number: {Rooms[i].RoomNr}. {Rooms[i].Description}, has been checked out of.");
                //sets the status of the room to not be checked into or booked
            }
            else
            {
                Console.WriteLine($"Error, Room number: {Rooms[i].RoomNr}. {Rooms[i].Description}, is currently not checked into.");
            }
        }
        else
        {
            Console.WriteLine($"Error! no room with roomnumber '{roomNr}' exists");
        }
    }

    public static void RoomAvaliability()
    //method for staff to check the availability of rooms
    {
        Console.WriteLine("Current room availability");
        foreach(Room r in Rooms)
        {
            if(r.isChecked == false)
            {
                Console.WriteLine($"Room number: {r.RoomNr}. {r.Description} is currently available");
            }
            else
            {
                Console.WriteLine($"Room number: {r.RoomNr}. {r.Description} is currently checked into");
            }
        }
        
    }  
}


