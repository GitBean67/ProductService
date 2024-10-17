
    using Microsoft.AspNetCore.Mvc;
    using OrderService.Models;
    using System.Collections.Generic;

    namespace OrderService.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class OrderController : ControllerBase
        {
            private static List<Order> orders = new List<Order>
        {
            new Order
            {
                OrderId = 1,
                OrderDate = DateTime.UtcNow,
                CustomerName = "John Doe",
                Products = new List<OrderItem>
                {
                    new OrderItem { ProductId = 1, ProductName = "Laptop", Price = 999.99M }
                }
            }
        };

            [HttpGet]
            public ActionResult<IEnumerable<Order>> GetOrders() => Ok(orders);

            [HttpGet("{id}")]
            public ActionResult<Order> GetOrder(int id)
            {
                var order = orders.Find(o => o.OrderId == id);
                if (order == null) return NotFound();
                return Ok(order);
            }

            [HttpPost]
            public ActionResult<Order> CreateOrder(Order order)
            {
                order.OrderId = orders.Count + 1;
                orders.Add(order);
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
        }
    }

