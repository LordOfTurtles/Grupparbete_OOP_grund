namespace Hotel_Management_Software;

class Program
{
    static void Main(string[] args)
    {
        Hotel.Rooms.Add(new Room("1", "Royal suite", 4000, 5, 4));
        Hotel.Rooms.Add(new Room("2", "Double room", 1500, 3, 2));
        Hotel.Rooms.Add(new Room("3", "Single room", 600, 1, 3));
        Hotel.Rooms.Add(new Room("4", "Family room", 1800, 5, 2));
        Hotel.RoomAvaliability();
        Hotel.CheckIn();
        Hotel.RoomAvaliability();
        Hotel.CheckOut();
        Hotel.RoomAvaliability();

    }
}
