using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{
    public class CarBuilder:ICarBuilder
    {
        private Car _car =new Car();
        public ICarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }
        public ICarBuilder SetColor(string colour)
        {
            _car.Colour = colour;
            return this;
        }
        public ICarBuilder SetWheels(int wheels)
        {
            _car.NumberOfWheels = wheels;
            return this;
        }
        public ICarBuilder SetSeats(int seats)
        {
            _car.NumberOfSeats = seats;
            return this;
        }

        public Car Build()
        {
            return _car;
        }
    }
}
