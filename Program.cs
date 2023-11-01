using System.Net.WebSockets;

namespace Hotel_Management_Software;

class Program
{

    static void Main(string[] args)
    {

        ConsoleUI.Initialize();
        
        /*Hotel.Rooms[2].roomBookings.Add(new Booking(new Guest("Sandra", "12738", "078532", "hej@hej.se"), new List<Room>(), new BookingPeriod(new DateOnly(2023, 12, 14), new DateOnly(2023, 12, 17)), 0.00, 1));
        Hotel.RoomAvaliability();
        Hotel.CheckIn();
        Hotel.RoomAvaliability();
        Hotel.CheckOut();
        Guest.AvaliableRooms();
        Guest.AvaliableRooms();*/

        ConsoleUI.MainMenu();

    }
}
