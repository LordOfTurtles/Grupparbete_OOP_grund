namespace Hotel_Management_Software;

class Booking
{
    //class for bookings made by guests, inludes a reference for a guest, a reference for a list of rooms, a reference for a bookingperiod, the total price for the booking, the total number of occupants and a review
    
    public Guest Guest;
    //the guest who made the booking
    public List<Room> BookedRooms = new List<Room>();
    //a list of rooms that are booked
    public BookingPeriod BookingPeriod;
    //a bookingperiod specifying a startdate and enddate
    public double TotalPrice;
    //the total price of the booking (prices of all the rooms x timeperiod)
    public int TotalOccupants;
    //input by the guest to be compared to the total capacity of the rooms to be booked
    public string Review;
    //a review written by the guest. Preferably at a nonspecified time after their stay.

    public Booking(Guest guest, List<Room> bookedRooms, BookingPeriod bookingPeriod, double totalPrice, int totalOccupants)
    {
        //constructor for the booking class, does not include review since that is to be added at a later time.
        Guest = guest;
        BookedRooms = bookedRooms;
        BookingPeriod = bookingPeriod;
        TotalPrice = totalPrice;
        TotalOccupants = totalOccupants;
    }
}
class BookingPeriod
{
    //class for the period of a specific booking, includes a startdate and an enddate
    public DateTime StartDate;
    public DateTime EndDate;
    public BookingPeriod(DateTime startDate, DateTime endDate)
    {
        StartDate = startDate;
        EndDate = endDate;
    }
}