namespace Hotel_Management_Software;

class Booking
{
    Guest Guest;
    public List<Room> BookedRooms = new List<Room>();

    DateTime StartDate;
    DateTime EndDate;
    double TotalPrice;
    int TotalOccupants;
    string Review;

    public Booking(Guest guest, List<Room> bookedRooms, DateTime startDate, DateTime endDate, double totalPrice, int totalOccupants)
    {
        Guest = guest;
        BookedRooms = bookedRooms;
        StartDate = startDate;
        EndDate = endDate;
        TotalPrice = totalPrice;
        TotalOccupants = totalOccupants;
    }

}