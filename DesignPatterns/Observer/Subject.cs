using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public class Subject:ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string ProductName {  get; set; }
        private int ProductPrice { get; set; }
        private string Availability { get; set; }

        public Subject(string productName, int productPrice,string availability)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Availability = availability;
        }

        public string GetAvailabilty()
        {
            return Availability;
        }

        public void setAvailibility(string availibility)
        {
            this.Availability = availibility;
            Console.WriteLine("Avalability Changed from Out of Stock to Avalable");
            NotifyObservers();
        }

        public void RegisterObserver(IObserver observer)
        {
            Console.WriteLine("Observer Added: " + ((Observer)observer).UserName);
            _observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            Console.WriteLine("Observer Remove: " + ((Observer)observer).UserName);
            _observers.Remove(observer);
        }
        public void NotifyObservers()
        {
            Console.WriteLine("Product Name :"
                            + ProductName + "Product Price: "
                            + ProductPrice + " Is Now Available");
            Console.WriteLine();
            foreach (var observer in _observers)
            {
                observer.Update(Availability);
            }
        }
    }
}
