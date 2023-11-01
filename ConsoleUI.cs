using System.Security.Cryptography.X509Certificates;
using Hotel_Management_Software;

class ConsoleUI
{
    public static void MainMenu()
    {
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("Welcome to Hotel Booking.");
            Console.WriteLine("Choose an option: \n1.Guest \n2.Staff");
            string userInput = Console.ReadLine()!;
            if(userInput == "1")
            {
                GuestMenu();
            }

            else if(userInput == "2")
            {
                StaffMenu();
            }

            else
            {
                Console.WriteLine("Invalid input.");
            }
        }      
    }

    public static void GuestMenu()
    {
        Guest guest = null!;
        Console.WriteLine("1. Log in\n2. Sign up as new guest\n3. Main menu");
        string userInput = Console.ReadLine()!;
        switch(userInput)
        {
            case "1":
                guest = LoginGuest();
            break;
            case "2":
                guest = RegisterGuest();
            break;
            case "3":
                MainMenu();
            break;
            default:
                Console.WriteLine("Error, invalid input");
                GuestMenu();
            break;          
        }
        bool isRunning = true;
        while(isRunning)
        {
            Console.WriteLine("Please select an option: \n1.Check availability \n2.Start a new booking \n3.Write a review \nLog out[x]");
            userInput = Console.ReadLine()!;
            switch(userInput)
            {
                case "1":
                    Console.WriteLine(Guest.AvaliableRooms());
                    Console.WriteLine("Would you like to book a room? [Y]/[N]");
                    userInput = Console.ReadLine()!;
                    //asks the guest if they want to book a room after looking at availability
                    if(userInput.ToLower() == "y")
                    {
                        BookingInput(guest);
                    }
                    else if(userInput.ToLower() == "n")
                    {

                    }
                    else
                    {
                        Console.WriteLine("Error, invalid input");
                    }
                break;

                case "2":
                BookingInput(guest);
                break;

                case "3":
                ReviewInput(guest);
                break;

                case "x":
                isRunning = false;
                break;

                default:
                Console.WriteLine("Invalid input.");
                break;

            }
        }
    }

    public static void StaffMenu()
    {
        bool isRunning = true;
        Console.WriteLine("Please enter admin password: ");
                string userInput = Console.ReadLine()!;

                if( userInput == Hotel.Password)
                {
                    
                    while(isRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Add or remove a room: \n2. Check in guest \n3. Check out guest: \n4. Check room avaliability:\nLog out[x] ");
                        userInput = Console.ReadLine()!;
                        switch(userInput)
                        {
                            case "1":
                            Console.WriteLine("Do you want to add or remove a room? [a]/[r]");
                            string input = Console.ReadLine()!;

                            if (input.ToLower() == "a")
                            {
                                Console.Write("Room number: ");
                                string roomNr = Console.ReadLine()!;

                                Console.Write("Description: ");
                                string description = Console.ReadLine()!;

                                Console.Write("Room price: ");
                                double roomPrice = double.Parse(Console.ReadLine()!);

                                Console.Write("Capacity: ");
                                int capacity = int.Parse(Console.ReadLine()!);     

                                Console.Write("Floor number: ");
                                int floorNr = int.Parse(Console.ReadLine()!);

                                Hotel.AddRoom(new Room(roomNr, description, roomPrice, capacity, floorNr));
                                //adds a new room with the details specified by the staff through console inputs
                            }
                            else if (input.ToLower() == "r")
                            {
                                int i = 0;
                                foreach(Room r in Hotel.Rooms)
                                {   
                                    i++;
                                    Console.WriteLine($"{i}.  {r.RoomNr}. '{r.Description}'");
                                }
                                //Lists all the rooms that are available to be removed with a corresponding number starting at 1
                                Console.Write("Choose room to be removed");
                                int remove = int.Parse(Console.ReadLine()!);
                                Hotel.RemoveRoom(remove -1);
                                //removes a room corresponding to the number input through the console
                            }
                            break;

                            case "2":
                            {
                                Console.Write("What roomnumber is getting checked into?: ");
                                string roomNr = Console.ReadLine()!;
                                if(Hotel.Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
                                //checks if a room with the roomnumber specified through the console exists
                                {
                                    int i = Hotel.Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
                                    //makes an integer for the index used in the list of rooms matching the roomnumber input by the staff
                                    if(Hotel.Rooms[i].roomBookings.Exists(x => x.IsChecked == true) && Hotel.Rooms[i].roomBookings.Count > 0)
                                    //checks that the specified room is not currently checked into and that there is a booking for the room
                                    {
                                        Console.WriteLine($"Error, Room number: {Hotel.Rooms[i].RoomNr}, '{Hotel.Rooms[i].Description}' is already checked into.");
                                    }
                                    else if(Hotel.Rooms[i].roomBookings.Count > 0)
                                    {
                                        int bNr = 1;
                                        foreach(Booking b in Hotel.Rooms[i].roomBookings)
                                        {
                                            Console.WriteLine($"{bNr}. {b.Guest.Name} {b.BookingPeriod}");
                                            bNr++;
                                        }
                                        Console.WriteLine("Please choose which booking you would like to check in: ");
                                        int uInput = int.Parse(Console.ReadLine()!) -1;
                                        if(uInput < Hotel.Rooms[i].roomBookings.Count)
                                        {
                                            Hotel.CheckIn(i, uInput);
                                            Console.WriteLine($"Room number: {Hotel.Rooms[i].RoomNr}, '{Hotel.Rooms[i].Description}' has been checked into.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error, invalid input");
                                        }
                                    
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Error, Room number: {Hotel.Rooms[i].RoomNr}, '{Hotel.Rooms[i].Description}' has not been booked.");
                                    }
                                    Console.WriteLine(GuestList.guestList[0].guestBookings[0].IsChecked);
                                }
                                else
                                {
                                    Console.WriteLine($"Error! no room with roomnumber '{roomNr}' exists");
                                }
                                Console.ReadKey();
                            }
                            break;

                            case "3":
                            {
                                Console.Write("What roomnumber is getting checked out of?: ");
                                string roomNr = Console.ReadLine()!;
                                if(Hotel.Rooms.Exists(x => x.RoomNr.Contains(roomNr)))
                                //checks if a room with the roomnumber specified through the console exists
                                {
                                    int i = Hotel.Rooms.FindIndex(x => x.RoomNr.Contains(roomNr));
                                    //makes an integer for the index used in the list of rooms matching the roomnumber input by the staff
                                    if(Hotel.Rooms[i].roomBookings.Exists(x => x.IsChecked == true))
                                    //checks that the specified room is currently checked into
                                    {
                                        int j = Hotel.Rooms[i].roomBookings.FindIndex(x => x.IsChecked == true);
                                        Console.WriteLine($"Room number: {Hotel.Rooms[i].RoomNr}. {Hotel.Rooms[i].Description}, has been checked out of.");
                                        Console.WriteLine("would you like to add an review? [y]/[n]");
                                        input = Console.ReadLine()!;
                                        if(input.ToLower() == "y")
                                        {
                                            Console.WriteLine("Please write your review: ");
                                            string review = Console.ReadLine()!;

                                            Guest.AddReview(Hotel.Rooms[i].roomBookings[j], review );


                                        }
                                        Hotel.CheckOut(i, j);

                                        //sets the status of the room to not be checked into or booked
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Error, Room number: {Hotel.Rooms[i].RoomNr}. {Hotel.Rooms[i].Description}, is currently not checked into.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Error! no room with roomnumber '{roomNr}' exists");
                                }
                                Console.WriteLine(GuestList.guestList[0].guestBookings[0].IsChecked);
                                Console.ReadKey();
                            }
                            break;

                            case "4":
                            Console.WriteLine(Hotel.RoomAvaliability());
                            Console.WriteLine("Press any key to continue");
                            Console.ReadKey();
                            break;

                            case "x":
                            isRunning = false;
                            break;

                            //direktBokning();

                            default:
                            Console.WriteLine("Invalid input");
                            break;


                        }
                    }

                    
                }

                else
                {
                    Console.WriteLine("incorrect password");
                }

                
    }

    static void BookingInput(Guest guest)
    {
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
                        Console.Write($"\n{bp.BookingPeriod.StartDate} until {bp.BookingPeriod.EndDate} ");
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
                        BookingPeriod myBp = new BookingPeriod(startDate, endDate);
                        roomBooking.Add(Hotel.Rooms[i]);
                        //Adds the chosen room to list of rooms to be booked
                        Booking myBooking = new Booking(guest, roomBooking, myBp, roomBooking[0].RoomPrice, roomBooking[0].Capacity);
                        Guest.BookRoom(myBooking, i, guest);
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
    }

    static void ReviewInput(Guest guest)
    {
        Console.WriteLine("Which booking do you want to review?");
        for( int i = 0; i < guest.guestBookings.Count; i++)
        {
            Console.WriteLine($"{i+1}. {guest.guestBookings[i]}");
        }
        int input = int.Parse(Console.ReadLine()!);

        Console.WriteLine("Enter your review here:");
        string review = Console.ReadLine()!;

        Guest.AddReview(guest.guestBookings[input -1],review);

        Console.WriteLine($"Review {guest.guestBookings[input-1].Review}");

    }
    static Guest LoginGuest()
    {
        Guest guest = null!;
        while(guest == null)
        {
            Console.Write("Please enter your email address: ");
            string email = Console.ReadLine()!;
            Console.Write("Please enter your password: ");
            string password = Console.ReadLine()!;
            guest = GuestList.LogInAttempt(email, password, out string outputmessage);
            Console.WriteLine(outputmessage);
            if(guest == null)
            {
                Console.WriteLine("1. Try again\n2. Register new guest\n3. Main menu");
                string userInput = Console.ReadLine()!;
                switch(userInput)
                {
                    case "1":
                    
                    break;
                    case "2":
                        guest = RegisterGuest();
                    break;
                    case "3":
                        MainMenu();
                    break;
                    default:
                    
                    break;
                }
            }
        }
        return guest;
           
    }
    static Guest RegisterGuest()
    {
        Console.WriteLine("Register new guest");
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Phone number:");
        string phoneNr = Console.ReadLine()!;
        Console.Write("Email: ");
        string email = Console.ReadLine()!;
        Console.Write("Password: ");
        string password = Console.ReadLine()!;
        Guest guest = new Guest(name, phoneNr, email, password);
        GuestList.AddGuest(guest);
        return guest;
}
}