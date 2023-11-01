namespace Hotel_Management_Software;

class Guest
{
    //class for guests, includes name of guest, an id, phonenr, email and a list of reviews made by the guest
    public string Name;
    public string PhoneNr;
    public string Email;
    public string Password;
    public List<Booking> guestBookings = new List<Booking>();
    //list of reviews made by a specific guest

    public Guest(string name, string phoneNr, string email, string password)
    {
        //constructor for the guest class, does not include a list of reviews which are added when written by the guest
        Name = name;
        PhoneNr = phoneNr;
        Email = email;
        Password = password;
    }

    public static string AvaliableRooms()
    {
        //method for checking what rooms are available and when, also offers the guest the option to book a room through calling on the BookRoom method
        string output = "Currently available rooms:";
        foreach(Room r in Hotel.Rooms)
        //goes through every room that exists in the static list in the hotel class
        {
            output += $"{r}\n";
        }
        return output;
    }

    public static void BookRoom(Room room, Booking myBooking, Guest guest)
    {
        room.roomBookings.Add(myBooking);
        guest.guestBookings.Add(myBooking);
    }
    //method for guests to book rooms
    
    public static void AddReview( Booking booking, string review)
    {
        //method for guest to write a review for a specific booking
        booking.Review = review;
    }
}

class GuestList
{
    public static List<Guest> guestList = new List<Guest>();

    public static void AddGuest(Guest guest)
    {
        guestList.Add(guest);
    }

    public static Guest LogInAttempt(string email, string password, out string outputMessage)
    {
        if(guestList.Exists(x => x.Email.Contains(email)))
        {
            Guest? guest = guestList.Find(x => x.Email.Contains(email));
            if(guest!.Password == password)
            {
                outputMessage = "Login successful";
                return guest;
            }
        }
        outputMessage = "Error, incorrect email or password";
        return null!;
    }
}