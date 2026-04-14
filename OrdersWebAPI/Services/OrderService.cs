using Microsoft.EntityFrameworkCore;
using OrdersWebAPI.Models;

namespace OrdersWebAPI.Services
{
    public class OrderService :IOrderService
    {
        private readonly OrderDBContext _dbContext;

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

        public async Task<int> AddOrder(Order order)
        {
            await _dbContext.Orders.AddAsync(order);
            int result = await _dbContext.SaveChangesAsync();
            return result;
        }

    }
}
