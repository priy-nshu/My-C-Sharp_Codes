using BykeStoreDBFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BykeStoreDBFirst.Services
{
    internal class BykeStoreDAL : DbContext
    {
        public string _ConStr;
        public BykeStoresContext Context;

        public BykeStoreDAL()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json", optional: false, reloadOnChange: true)
                .Build();

            _ConStr = config.GetConnectionString("BykeCon");
            Context = new BykeStoresContext(_ConStr);
        }
        public int AddCustomer(Customer customer)
        {
            Context.Customers.Add(customer);
            int result= Context.SaveChanges();
            return result;
        }

        public void DisplayCustomers()
        {
            foreach (var c in Context.Customers)
                Console.WriteLine($"Customer ID: {c.CustomerId}, Name: {c.FirstName} {c.LastName}");
        }

        public int UpdateCustomer(Customer customer)
        {
            Context.Entry(customer).State = EntityState.Modified;
            int result= Context.SaveChanges();
            return result;
        }

        public Customer GetCustomerById(int id)
        {
            return Context.Customers.FirstOrDefault(c => c.CustomerId == id);
        }
        public int DeleteCustomer(Customer customer)
        {
            //Context.Customers.Remove(std);
            //      OR
            Context.Customers.Entry(customer).State = EntityState.Deleted;
            int result = Context.SaveChanges();
            return result;
        }
    }
}
