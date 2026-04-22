using Microsoft.EntityFrameworkCore;
using SalesLTWebAPI.Models;

namespace SalesLTWebAPI.Services
{
    public class CustomerService : ICustomerService
    {
            private readonly MydatabaseContext _context;

            public CustomerService(MydatabaseContext context)
            {
                _context = context;
            }

            // GET: All customers
            public async Task<IEnumerable<Customer>> GetCustomers()
            {
                return await _context.Customers.ToListAsync();
            }

            // GET: Customer by ID
            public async Task<Customer?> GetCustomersById(int id)
            {
                return await _context.Customers.FindAsync(id);
            }

            // PUT: Update customer
            public async Task<int> PutCustomer(int id, Customer customer)
            {
                if (id != customer.CustomerId)
                {
                    return 0; // or throw exception
                }

                _context.Entry(customer).State = EntityState.Modified;

                try
                {
                    return await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await CustomerExists(id))
                    {
                        return -1; // not found
                    }
                    throw;
                }
            }

            // POST: Create new customer
            public async Task<Customer> PostCustomers(Customer customer)
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return customer;
            }

            // DELETE: Remove customer
            public async Task<int> DeleteCustomers(int id)
            {
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return 0;
                }

                _context.Customers.Remove(customer);
                return await _context.SaveChangesAsync();
            }

            // CHECK: Customer exists
            public async Task<bool> CustomerExists(int id)
            {
                return await _context.Customers.AnyAsync(e => e.CustomerId == id);
            }
        }
    }

