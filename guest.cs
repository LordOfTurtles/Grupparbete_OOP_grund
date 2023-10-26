namespace Hotel_Management_Software;

class Guest
{
    //class for guests, includes name of guest, an id, phonenr, email and a list of reviews made by the guest
    string Name;
    string GuestId;
    string PhoneNr;
    string Email;
    public List<string> guestReview = new List<string>();
    //list of reviews made by a specific guest

    public Guest(string name, string guesId, string phoneNr, string email)
    {
        //constructor for the guest class, does not include a list of reviews which are added when written by the guest
        Name = name;
        GuestId = guesId;
        PhoneNr = phoneNr;
        Email = email;
    }

    public static void AvaliableRooms()
    {
        //method for checking what rooms are available and when, also offers the guest the option to book a room through calling on the BookRoom method
        Console.WriteLine("Currently available rooms:");
        foreach(Room r in Hotel.Rooms)
        //goes through every room that exists in the static list in the hotel class
        {
            Console.WriteLine($"Room number: {r.RoomNr}. '{r.Description}'\nPrice: {r.RoomPrice}kr Capacity: {r.Capacity}");
            Console.Write("Currently booked dates: ");
            if(r.roomBookings.Count > 0)
            //checks if there are any bookings in the current room "r"
            {
                foreach(Booking bp in r.roomBookings)
                {
                    Console.Write($"\n{bp.BookingPeriod.StartDate} until {bp.BookingPeriod.EndDate} ");
                }
                //types out every booking that is currently made for room "r"
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("No bookings at the moment");
            }
            Console.WriteLine("");
        }
        Console.WriteLine("Would you like to book a room? [Y]/[N]");
        string userInput = Console.ReadLine()!;
        //asks the guest if they want to book a room after looking at availability
        if(userInput.ToLower() == "y")
        {
            BookRoom();
        }
        else if(userInput.ToLower() == "n")
        {

        }
        else
        {
            Console.WriteLine("Error, invalid input");
        }
    }

    static void BookRoom()
    //method for guests to book rooms
    {
        List<Room> roomBooking = new List<Room>();
        //a temporary list in which rooms that are to be booked are added
        Console.Write("What roomnumber would you like to book?: ");
        string roomNr = Console.ReadLine()!;
        if(Hotel.Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
        //checks if the roomnumber input by the guest matches one in the list of rooms for the hotel
        {
            int i = Hotel.Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
            //makes an integer for the index used in the list of rooms matching the roomnumber input by the guest
            Console.WriteLine($"Currently booked periods for room number {Hotel.Rooms[i].RoomNr}. '{Hotel.Rooms[i].Description}':");
            foreach(Booking bp in Hotel.Rooms[i].roomBookings)
            //types out the currently booked periods for the room chosen
                {
                    Console.Write($"\n{bp.BookingPeriod.StartDate} until {bp.BookingPeriod.EndDate}");
                }       
            Console.WriteLine($"check in at: 15.00");
            Console.Write("\nPlease input a startdate for your booking (mm/dd/yyyy): ");
            string userInput = Console.ReadLine()!;
            if(DateOnly.TryParse(userInput, out DateOnly startDate) == true)
            //checks if the string "userInput" input by the guest is in a valid format for being converted to DateTime and if so produces a DateTime variable "startDate"
            {
                Console.WriteLine(startDate);
                Console.WriteLine("check out at 11.00");
                Console.Write("\nPlease input an enddate for your booking (mm/dd/yyyy):");
                userInput = Console.ReadLine()!;
                if(DateOnly.TryParse(userInput, out DateOnly endDate) == true)
                //checks if the string "userInput" input by the guest is in a valid format for being converted to DateTime and if so produces a DateTime variable "endDate"
                {
                    Hotel.Rooms[i].isBooked = true;
                    BookingPeriod myBp = new BookingPeriod(startDate, endDate);
                    roomBooking.Add(Hotel.Rooms[i]);
                    //Adds the chosen room to list of rooms to be booked
                    Booking myBooking = new Booking(new Guest("Erik", "19940617", "0763293705", "erik@nbi.se"), roomBooking, myBp, roomBooking[0].RoomPrice, roomBooking[0].Capacity);
                    Hotel.Rooms[i].roomBookings.Add(myBooking);
                    Console.WriteLine($"{myBooking.Guest.Name}, {myBooking.BookedRooms[0].RoomNr}, Period: {myBooking.BookingPeriod.StartDate} until {myBooking.BookingPeriod.EndDate} check in at: {myBooking.BookingPeriod.StartTime} check out at: {myBooking.BookingPeriod.EndTime}");
                }
                else
                {
                    Console.WriteLine("Error, incorrect format for enddate");
                }
            }
            else
            {
                Console.WriteLine("Error, incorrect format for startdate");
            }
        }
    }
    static void WriteReview()
    {
        //method for guest to write a review for a specific booking
    }
}