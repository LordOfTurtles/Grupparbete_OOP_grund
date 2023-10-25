
using System.Security.Cryptography.X509Certificates;

namespace Hotel_Management_Software;

class Hotel
{
    public string Name;
    public int CurrentGuests;

    public static List<Room> Rooms = new List<Room>();

    public static void AddRemoveRoom()
    {
        Console.WriteLine("Do you want to add or remove a room?");
        string input = Console.ReadLine()!;

        if (input.ToLower() == "a")
        {
            Console.Write("Room number: ");
            string roomNr = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Room price: ");
            double roomPrice = double.Parse(Console.ReadLine());

            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());     

            Console.Write("Floor number: ");
            int floorNr = int.Parse(Console.ReadLine());

            Rooms.Add(new Room(roomNr, description, roomPrice, capacity, floorNr));
        }
        else if (input.ToLower() == "r")
        {
            int i = 0;
            foreach(Room r in Rooms )
            {   
                i++;
                Console.WriteLine($"{i}.  {r.RoomNr}");

            }

            int remove = int.Parse(Console.ReadLine());
            Rooms.RemoveAt(remove -1);
            
        }


    }

    public static void CheckIn()
    {

        Console.Write("What roomnumber is getting checked into?: ");
        string roomNr = Console.ReadLine()!;
        if(Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
        {
            int i = Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
            if(Rooms[i].isChecked == false)
            {
            Rooms[i].isChecked = true;
            Console.WriteLine($"Room number: {Rooms[i].RoomNr}, {Rooms[i].Description}. has been checked into.");
            }
            else
            {
                Console.WriteLine($"Error, Room number: {Rooms[i].RoomNr}, {Rooms[i].Description}. is already checked into.");
            }
        }
        else
        {
            Console.WriteLine($"Error! no room with roomnumber '{roomNr}' exists");
        }
    }

    public static void  CheckOut()
    {
        Console.Write("What roomnumber is getting checked out of?: ");
        string roomNr = Console.ReadLine()!;
        if(Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
        {
            int i = Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
            if(Rooms[i].isChecked == true)
            {
                Rooms[i].isChecked = false;
                Console.WriteLine($"Room number: {Rooms[i].RoomNr}. {Rooms[i].Description}, has been checked out of.");
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


