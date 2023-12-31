
using System.Security.Cryptography.X509Certificates;

namespace Hotel_Management_Software;

//class for a specific hotel, including its name, how many guests are currently staying and a list of all the rooms
class Hotel

{
    public string? Name;
    public int CurrentGuests;

    public static string Password = "Hotel123";
    public static List<Room> Rooms = new List<Room>();
    //list of rooms at the hotel
    
    //method for staff to add rooms through the console
    public static void AddRoom(Room r)
    {
        Rooms.Add(r);
    }

    //method for staff to remove rooms through the console
    public static void RemoveRoom(int remove)
    {
        Rooms.RemoveAt(remove);
    }

    //method for staff to check in guests to a room
    public static void CheckIn(int i, int uInput)
    {
        Rooms[i].roomBookings[uInput].IsChecked = true;
    }

    //method for staff to check guests out of their room
    public static void  CheckOut(Booking b, Room r)
    
    {
        b.IsChecked = false;
        r.pastBookings.Add(b);
        b.Guest.guestPastBookings.Add(b);
        r.roomBookings.Remove(b);

    }

    //method for staff to check the availability of rooms
    public static string RoomAvaliability()
    
    {
        string output = "Current room availability";
        foreach(Room r in Rooms)
        {
            if(r.roomBookings.Exists(x => x.IsChecked == true))
            {
                output += $"{r}\nStatus: Unavailable\n";
            }
            else
            {
                output += $"{r} \nStatus: Available\n";
            }
        }
        return output;
        
    }  
}


