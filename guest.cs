namespace Hotel_Management_Software;

class Guest
{
    string Name;
    string GuestId;
    string PhoneNr;
    string Email;
    public List<string> guestReview = new List<string>();

    public Guest(string name, string guesId, string phoneNr, string email)
    {
        Name = name;
        GuestId = guesId;
        PhoneNr = phoneNr;
        Email = email;

    }

    static void AvaliableRooms()
    {

    }

    static void BookRoom()
    {

    }
    static void WriteReview()
    {
        
    }
}