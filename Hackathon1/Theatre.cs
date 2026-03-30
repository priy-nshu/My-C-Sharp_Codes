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

<<<<<<< HEAD
        public int TheatreID { get; set; }
        public string TheatreName { get; set; }
        public int NumberOfSeats { get; set; }

        public Theatre(string name, int seat)
=======
        public int TheatreID {  get; set; }
        public string TheatreName {  get; set; }
        public int NumberOfSeats { get; set; }

        public Theatre(string name,int seat)
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
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
<<<<<<< HEAD
            Console.WriteLine($"Seats        :{NumberOfSeats}");
=======
            Console.WriteLine($"Seats        :{ NumberOfSeats}");
>>>>>>> ca973e6edfc4a47fab7f244dfc44b86289a76d21
        }
    }
}
