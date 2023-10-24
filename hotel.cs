
namespace Hotel_Management_Software;

class Hotel
{
    public string Name;
    public int CurrentGuests;

    public static List<Room> Rooms = new List<Room>();

    public static void AddRemoveRoom()
    {
        Console.WriteLine("Do you want to add or remove a room?");
        string input = Console.ReadLine()!;

        if (input.ToLower() == "a")
        {
            Console.Write("Room number: ");
            string roomNr = Console.ReadLine();

            Console.Write("Description: ");
            string description = Console.ReadLine();

            Console.Write("Room price: ");
            double roomPrice = double.Parse(Console.ReadLine());

            Console.Write("Capacity: ");
            int capacity = int.Parse(Console.ReadLine());     

            Console.Write("Floor number: ");
            int floorNr = int.Parse(Console.ReadLine());

            Rooms.Add(new Room(roomNr, description, roomPrice, capacity, floorNr));
        }
        else if (input.ToLower() == "r")
        {
            int i = 0;
            foreach(Room r in Rooms )
            {   
                i++;
                Console.WriteLine($"{i}.  {r.RoomNr}");

            }

            int remove = int.Parse(Console.ReadLine());
            Rooms.RemoveAt(remove -1);
            
        }


    }

    static void CheckIn()
    {

    }

    static void  CheckOut()
    {

    }

    static void RoomAvaliability()
    {

    }
    
}


