using SalesLTWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace SalesLTWebAPI.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomersById(int id);
        Task<int> PutCustomer(int id, Customer customer);
        Task<Customer> PostCustomers(Customer customer);
        Task<int> DeleteCustomers(int id);
        Task<bool> CustomerExists(int id);
    }
}
