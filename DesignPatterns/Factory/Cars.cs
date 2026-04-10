using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class Cars :IVehicle
    {
        public void DisplayInfo()
        {
            Console.WriteLine("This is a Car");
        }
    }
}
