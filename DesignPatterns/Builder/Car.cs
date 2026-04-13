using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class Car
    {
        public string Engine { get; set; }
        public string Colour { get; set; }
        public int NumberOfWheels { get; set; }
        public int NumberOfSeats { get; set; }

        public void display()
        {
            Console.WriteLine($"\n---- Car Details ---");
            Console.WriteLine($"Engine: {Engine}");
            Console.WriteLine($"Colour: {Colour}");
            Console.WriteLine($"Number of Wheels: {NumberOfWheels}");
            Console.WriteLine($"Seats: {NumberOfSeats}");
        }
    }
}
