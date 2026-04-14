using Microsoft.EntityFrameworkCore;
using OrdersWebAPI.Models;
using System.Net.Http;

namespace OrdersWebAPI.Services
{
    public class OrderService :IOrderService
    {
        private readonly OrderDBContext _dbContext;
        private readonly HttpClient httpClient;
        private readonly string productURL="https://localhost:7025/api/product" ;

        public OrderService(OrderDBContext orderDBContext)
        {
            _dbContext = orderDBContext;
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _dbContext.Orders.FirstOrDefaultAsync(o => o.OrderId == id);
        }

        //public async Task<int> AddOrder(Order order)
        //{
        //    int status = 0;
        //    foreach(var item in order.OrderItems)
        //    {
        //        var productResponse =await httpClient.GetAsync($"{productURL}/GetProductById{item.ProductId}");
        //        if (!productResponse.IsSuccessStatusCode)
        //        {
        //            order.OrderItems.Remove(item);
        //            status = -1;
        //        }
        //    }
        //    //if(status== -1)
        //    //{
        //    //    return 0;
        //    //}

        //    await _dbContext.Orders.AddAsync(order);
        //    int result = await _dbContext.SaveChangesAsync();

        //    foreach(var items in order.OrderItems)
        //    {
        //        items.OrderId = order.OrderId;
        //    }

        //    if (result > 0)
        //    {
        //        await _dbContext.Orders.AddRangeAsync(order);
        //        int result2 = await _dbContext.SaveChangesAsync();
        //    }
        //    return result;
        //}
        public async Task<int> AddOrder(Order order)
        {
            // 1. SAFETY: Check if order items exist before doing anything
            if (order.OrderItems != null && order.OrderItems.Any())
            {
                // 2. FIX FOR FOREACH CRASH: Create a temporary copy of the list using .ToList()
                // This allows us to safely iterate over the copy, while removing from the original list!
                var itemsToCheck = order.OrderItems.ToList();

                foreach (var item in itemsToCheck)
                {
                    // FIXED URL: Added the missing "/"
                    var productResponse = await httpClient.GetAsync($"{productURL}/GetProductById/{item.ProductId}");

                    if (!productResponse.IsSuccessStatusCode)
                    {
                        // Now it is perfectly safe to remove the item from the original order
                        order.OrderItems.Remove(item);
                    }
                }
            }

            // Optional: If all items were invalid and removed, maybe we shouldn't save an empty order?
            // Uncomment the next line if you want to block empty orders:
            // if (order.OrderItems == null || !order.OrderItems.Any()) return 0;

            // 3. FIX FOR DOUBLE SAVE: Let Entity Framework do the hard work!
            // Adding the 'order' automatically adds the remaining valid 'order.OrderItems' too.
            await _dbContext.Orders.AddAsync(order);

            // This ONE save automatically generates the orderId, and assigns it to all the items.
            int result = await _dbContext.SaveChangesAsync();

            // Do NOT write a second SaveChangesAsync() or manual ID mapping. EF Core already did it!

            return result;
        }

    }
}
