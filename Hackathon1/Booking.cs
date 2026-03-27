using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class Booking
    {
        static int nextId = 1000;

        public int BookingID { get; set; }
        public int ShowID { get; set; }
        public int NumberOfSeats { get; set; }
        public DateTime BookingDate { get; set; }
        public string CustomerName { get; set; }
        public string SeatType { get; set; }
        public string BookingStatus { get; set; }
        public string Email { get; set; }
        public decimal Amount { get; set; }
        public List<int> SeatNumbers { get; set; }

        public Booking(int showID, string customerName, int numberOfSeats, string seatType, string email)
        {
            if (numberOfSeats <= 0 || numberOfSeats > 4)
            {
                throw new ArgumentException("Number of seats must be between 1 and 4.");
            }

            this.BookingID = nextId++;
            this.ShowID = showID;
            this.CustomerName = customerName;
            this.NumberOfSeats = numberOfSeats;
            this.SeatType = seatType;
            this.Email = email;

            this.BookingDate = DateTime.Now;
            this.BookingStatus = "Reserved";

            this.SeatNumbers = new List<int>();
            for (int i = 1; i <= numberOfSeats; i++)
            {
                SeatNumbers.Add(i);
            }
            decimal seatTemp = seatType.ToLower() == "platinum" ? 200m : seatType.ToLower() == "gold" ? 150m : 100m;
            this.Amount = this.NumberOfSeats * seatTemp;
        }
        public void DisplayBookingDetails()
        {
            Console.WriteLine("\n--- Booking Details ---");
            Console.WriteLine($"Booking ID: {BookingID} | Status: {BookingStatus}");
            Console.WriteLine($"Show ID: {ShowID} | Date: {BookingDate}");
            Console.WriteLine($"Customer: {CustomerName} ({Email})");
            Console.WriteLine($"Seats: {NumberOfSeats} ({SeatType}) | Seat Nos: {SeatNumbers}");
            Console.WriteLine($"Total Amount: {Amount:C}");
        }
    }
}
