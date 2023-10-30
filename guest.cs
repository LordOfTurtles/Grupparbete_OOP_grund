namespace Hotel_Management_Software;

class Guest
{
    //class for guests, includes name of guest, an id, phonenr, email and a list of reviews made by the guest
    public string Name;
    public string PhoneNr;
    public string Email;
    public List<Booking> guestBookings = new List<Booking>();
    //list of reviews made by a specific guest

    public Guest(string name, string phoneNr, string email)
    {
        //constructor for the guest class, does not include a list of reviews which are added when written by the guest
        Name = name;
        PhoneNr = phoneNr;
        Email = email;
    }

    public static string AvaliableRooms()
    {
        //method for checking what rooms are available and when, also offers the guest the option to book a room through calling on the BookRoom method
        Console.WriteLine("Currently available rooms:");
        string output = "";
        foreach(Room r in Hotel.Rooms)
        //goes through every room that exists in the static list in the hotel class
        {
            output += $"{r}\n";
        }
        return output;
    }

    public static void BookRoom(Booking myBooking, int i, Guest guest)
    {
        Hotel.Rooms[i].roomBookings.Add(myBooking);
        guest.guestBookings.Add(myBooking);
    }
    //method for guests to book rooms
    
    public static string WriteReview(Guest guest, out int i)
    {
        //method for guest to write a review for a specific booking
        System.Console.WriteLine("Enter your review here:");
        string review = Console.ReadLine()!;
        i = 0;
        return review;
    }
}