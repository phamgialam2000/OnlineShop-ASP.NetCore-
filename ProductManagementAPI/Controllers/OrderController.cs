using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interface;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _OrderRepository;
        public OrderController(IOrderRepository OrderRepository)
        {
            _OrderRepository = OrderRepository;
        }
        // GET: OrderController
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrder()
        {
            return await _OrderRepository.GetAllOrder();
        }

        // GET: OrderController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _OrderRepository.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        //POST: OrderController/Create
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _OrderRepository.AddOrder(order);
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }
        // PUT: OrderController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            var temp = await _OrderRepository.GetOrderById(id);
            if (temp == null)
            {
                return NotFound();
            }
            order.OrderId = id;
            await _OrderRepository.UpdateOrder(order);
            return Content("Update success");
        }
        // DELETE: OrderController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var Order = await _OrderRepository.GetOrderById(id);
            if (Order == null)
            {
                return NotFound();
            }
            await _OrderRepository.DeleteOrder(id);
            return Content("Delete success");
        }

    }
        
}
