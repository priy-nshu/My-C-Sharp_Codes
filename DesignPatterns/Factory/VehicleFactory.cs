using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory
{
    public class VehicleFactory
    {
        public IVehicle CreateVehicle(string type)
        {
            switch (type.ToLower())
            {
                case "car":
                    return new Cars();
                case "truck":
                    return new Truck();
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
        }
    }
}
