namespace Hotel_Management_Software;

class Program
{
    static void Main(string[] args)
    {
        Hotel.Rooms.Add(new Room("1", "Royal suite", 3999.99, 5, 4));
        Hotel.Rooms.Add(new Room("2", "Double room", 1499.99, 3, 2));
        Hotel.Rooms.Add(new Room("3", "Single room", 599.99, 1, 3));
        Hotel.Rooms.Add(new Room("4", "Family room", 1799.99, 5, 2));
        Hotel.Rooms[2].roomBookings.Add(new Booking(new Guest("Sandra", "12738", "078532", "hej@hej.se"), new List<Room>(), new BookingPeriod(new DateOnly(2023, 12, 14), new DateOnly(2023, 12, 17)), 0.00, 1));
        Hotel.RoomAvaliability();
        Hotel.CheckIn();
        Hotel.RoomAvaliability();
        Hotel.CheckOut();
        Guest.AvaliableRooms();
        Guest.AvaliableRooms();

    }
}
