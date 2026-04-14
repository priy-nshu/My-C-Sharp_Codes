using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrdersWebAPI.Models;
using OrdersWebAPI.Services;

namespace OrdersWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        // Injecting the service via the constructor
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders); // Returns 200 OK with the list of orders
            }
            catch (Exception ex)
            {
                // In a real app, log the exception here
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);

                if (order == null)
                {
                    return NotFound($"Order with ID {id} not found."); // Returns 404 if not found
                }

                return Ok(order); // Returns 200 OK with the specific order
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> AddOrder( Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object"); // Returns 400 if validation fails
                }

                int result = await _orderService.AddOrder(order);

                if (result > 0)
                {
                    // Returns 201 Created and points to the GET method to retrieve the newly created order
                    return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
                }

                return BadRequest("Failed to add order to the database.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}