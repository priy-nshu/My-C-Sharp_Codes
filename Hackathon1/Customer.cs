using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon1
{
    internal class Customer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public string City { get; set; }
        public Customer(string name, string city)
        {
            CustomerName = name;
            City = city;
        }

        public void DisplayCustomerDetails()
        {
            Console.WriteLine("----Customer Details----");
            Console.WriteLine($"Customer ID   :{CustomerID}");
            Console.WriteLine($"Customer Name :{CustomerName}");
            Console.WriteLine($"Cituy        :{City}");
        }
    }
}
