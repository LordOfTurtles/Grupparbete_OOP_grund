namespace Hotel_Management_Software;

class Room
{
    public string RoomNr;
    public string Description;
    public bool isBooked;
    public bool isChecked;
    double RoomPrice;
    int Capacity;

    int FloorNr;

    public Room(string roomNr, string description, double roomPrice, int capacity, int floorNr)
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

