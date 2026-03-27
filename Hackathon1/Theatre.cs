using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class Theatre
    {
        static int nextId = 1000;

        public int TheatreID { get; set; }
        public string TheatreName { get; set; }
        public int NumberOfSeats { get; set; }

        public Theatre(string name, int seat)
        {
            TheatreID = nextId++;
            TheatreName = name;
            NumberOfSeats = seat;
        }

        public void DisplayTheatreDetails()
        {
            Console.WriteLine("----Theatre Details----");
            Console.WriteLine($"Theatre ID   :{TheatreID}");
            Console.WriteLine($"Theatre Name :{TheatreName}");
            Console.WriteLine($"Seats        :{NumberOfSeats}");
        }
    }
}
