
using System.Security.Cryptography.X509Certificates;

namespace Hotel_Management_Software;

class Hotel
//class for a specific hotel, including its name, how many guests are currently staying and a list of all the rooms
{
    public string Name;
    public int CurrentGuests;

    public static string Password = "Hotel123";
    public static List<Room> Rooms = new List<Room>();
    //list of rooms at the hotel
    public static void AddRoom(Room r)
    //method for staff to add rooms through the console
    {
        Rooms.Add(r);
    }

    public static void RemoveRoom(int remove)
    //method for staff to remove rooms through the console
    {
        Rooms.RemoveAt(remove);
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
            if(Rooms[i].roomBookings.Exists(x => x.IsChecked == true) && Rooms[i].roomBookings.Count > 0)
            //checks that the specified room is not currently checked into and that there is a booking for the room
            {
                Console.WriteLine($"Error, Room number: {Rooms[i].RoomNr}, '{Rooms[i].Description}' is already checked into.");
            }
            else if(Rooms[i].roomBookings.Count > 0)
            {
                int bNr = 1;
                foreach(Booking b in Rooms[i].roomBookings)
                {
                    Console.WriteLine($"{bNr}. {b.Guest.Name} {b.BookingPeriod}");
                    bNr++;
                }
                Console.WriteLine("Please choose which booking you would like to check in: ");
                int userInput = int.Parse(Console.ReadLine()) -1;
                if(userInput < Rooms[i].roomBookings.Count)
                {
                    Rooms[i].roomBookings[userInput].IsChecked = true;
                    Console.WriteLine($"Room number: {Rooms[i].RoomNr}, '{Rooms[i].Description}' has been checked into.");
                }
                else
                {
                    Console.WriteLine("Error, invalid input");
                }
            
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
        Console.ReadKey();
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
            if(Rooms[i].roomBookings.Exists(x => x.IsChecked == true))
            //checks that the specified room is currently checked into
            {
                int j = Rooms[i].roomBookings.FindIndex(x => x.IsChecked == true);
                Rooms[i].roomBookings.RemoveAt(j);
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
            if(r.roomBookings.Exists(x => x.IsChecked == true))
            {
                Console.WriteLine($"{r}\nStatus: Unavailable\n");
            }
            else
            {
                Console.WriteLine($"{r} \nStatus: Available\n");
            }
        }
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
        
    }  
}


