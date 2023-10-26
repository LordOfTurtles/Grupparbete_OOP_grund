using System.Net.WebSockets;

namespace Hotel_Management_Software;

class Program
{
    static void Main(string[] args)
    {
        Hotel.Rooms.Add(new Room("1", "Royal suite", 3999.99, 5, 4));
        Hotel.Rooms.Add(new Room("2", "Double room", 1499.99, 3, 2));
        Hotel.Rooms.Add(new Room("3", "Single room", 599.99, 1, 3));
        Hotel.Rooms.Add(new Room("4", "Family room", 1799.99, 5, 2));
        /*Hotel.Rooms[2].roomBookings.Add(new Booking(new Guest("Sandra", "12738", "078532", "hej@hej.se"), new List<Room>(), new BookingPeriod(new DateOnly(2023, 12, 14), new DateOnly(2023, 12, 17)), 0.00, 1));
        Hotel.RoomAvaliability();
        Hotel.CheckIn();
        Hotel.RoomAvaliability();
        Hotel.CheckOut();
        Guest.AvaliableRooms();
        Guest.AvaliableRooms();*/

        System.Console.WriteLine("Welcome to Hotel Booking.");
        bool isRunning = true;
        System.Console.WriteLine("Choose an option: \n1.Guest \n2.Staff");
        string userInput = Console.ReadLine()!;
        if(userInput == "1")
        {
            System.Console.WriteLine("Register new guest");
            System.Console.WriteLine("Name: ");
            string name = Console.ReadLine()!;
            System.Console.WriteLine("Phone number:");
            string phoneNr = Console.ReadLine()!;
            System.Console.WriteLine("Email: ");
            string email = Console.ReadLine()!;

            Guest guest = new Guest(name, phoneNr, email);

            while(isRunning)
            {
                System.Console.WriteLine("Please select an option: \n1.Check availability \n2.Start a new booking \n3.Write a review");
                userInput = Console.ReadLine()!;
                switch(userInput)
                {
                    case "1":
                    Guest.AvaliableRooms(guest);
                    break;

                    case "2":
                    guest.guestBookings.Add(Guest.BookRoom(guest));
                    break;

                    case "3":
                    string review = Guest.WriteReview(guest, out int i);
                    guest.guestBookings[i].Review = review;
                    break;

                    default:
                    System.Console.WriteLine("Invalid input.");
                    break;

                }
            }
        }

        else if(userInput == "2")
        {

        }

        else
        {
            System.Console.WriteLine("Invalid input.");
        }
    }
}
