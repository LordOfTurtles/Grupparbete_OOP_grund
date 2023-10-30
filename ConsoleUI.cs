using Hotel_Management_Software;

class ConsoleUI
{
    public static void MainMenu()
    {
        bool mainMeny = true;
        while(mainMeny)
        {
            System.Console.WriteLine("Welcome to Hotel Booking.");
            bool isRunning = true;
            System.Console.WriteLine("Choose an option: \n1.Guest \n2.Staff");
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
                System.Console.WriteLine("Invalid input.");
            }

        }
        
    }

    public static void GuestMenu()
    {
        bool isRunning = true;
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
                    System.Console.WriteLine("Please select an option: \n1.Check availability \n2.Start a new booking \n3.Write a review \nLog out[x]");
                    string userInput = Console.ReadLine()!;
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
                        string review = Guest.WriteReview(guest, out int i);
                        guest.guestBookings[i].Review = review;
                        break;

                        case "x":
                        isRunning = false;
                        break;

                        default:
                        System.Console.WriteLine("Invalid input.");
                        break;

                    }
                }
    }

    public static void StaffMenu()
    {
        bool isRunning = true;
        System.Console.WriteLine("Please enter admin password: ");
                string userInput = Console.ReadLine();

                if( userInput == Hotel.Password)
                {
                    
                    while(isRunning)
                    {
                        Console.Clear();
                        Console.WriteLine("1. Add or remove a room: \n2. Check in guest \n3. Check out guest: \n4. Check room avaliability:\nLog out[x] ");
                        userInput = Console.ReadLine();
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
                            Hotel.CheckIn();
                            break;

                            case "3":
                            Hotel.CheckOut();
                            break;

                            case "4":
                            Hotel.RoomAvaliability();
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
}