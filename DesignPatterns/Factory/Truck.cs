using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Truck:IVehicle
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is a Truck");
        }
    }
}
