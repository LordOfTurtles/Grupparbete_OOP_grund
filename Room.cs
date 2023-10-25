namespace Hotel_Management_Software;

class Room
//class for rooms at the hotel, includes a list of periods during which the room is booked, a roomnumber, a description of the room, bools for whether the room is checked into/booked or not, a price for one night, guest capacity and floor number
{
    public List<Booking> roomBookings = new List<Booking>();
    public string RoomNr;
    public string Description;
    public bool isBooked;
    public bool isChecked;
    public double RoomPrice;
    public int Capacity;

    public int FloorNr;

    public Room(string roomNr, string description, double roomPrice, int capacity, int floorNr)
    //constructor for the room class, does not include a list of bookingperiods since those are added/removed when the room is booked or checked out of
    {
        RoomNr  = roomNr;
        Description = description;
        RoomPrice = roomPrice;
        Capacity = capacity;
        FloorNr = floorNr;
        isBooked = false;
        isChecked = false;
    }
}

