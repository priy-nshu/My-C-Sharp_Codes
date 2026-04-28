using Microsoft.AspNetCore.Mvc;
using HttpTriggers.Models;

namespace HttpTriggers.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();

        Task<Customer> GetCustomersById(int id);
        //    Task<int> PutCustomer(int id, Customer customer);
        Task<Customer> PostCustomers(Customer customer);
        //    Task<int> DeleteCustomers(int id);
        //    Task<bool> CustomerExists(int id);
        //}
    }
}
