using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Interface;

namespace OrderDetailManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailRepository _OrderDetailRepository;
        public OrderDetailController(IOrderDetailRepository OrderDetailRepository)
        {
            _OrderDetailRepository = OrderDetailRepository;
        }
        // GET: OrderDetailController
        [HttpGet]
        public async Task<IEnumerable<OrderDetail>> GetOrderDetail()
        {
            return await _OrderDetailRepository.GetAllOrderDetail();
        }

        // GET: OrderDetailController/Details/5
        [HttpGet("Order/{id}")]
        public async Task<ActionResult<OrderDetail>> GetByOrderDetailId(int id)
        {
            var orderDetail = await _OrderDetailRepository.GetOrderDetailByOrderId(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }
        //POST: OrderDetailController/Create
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            await _OrderDetailRepository.AddOrderDetail(orderDetail);
            return Content("Insert success");

        }
        // PUT: OrderDetailController/3/5
        [HttpPut("{OrderId}/{ProductId}")]
        public async Task<IActionResult> PutOrderDetail(int orderId, int productId, OrderDetail orderDetail)
        {
            var temp = await _OrderDetailRepository.GetOrderDetailByOrderIdProductId(orderId, orderDetail.ProductId);
            if (temp == null)
            {
                return NotFound();
            }
            orderDetail.OrderId = orderId;
            orderDetail.ProductId = productId;
            await _OrderDetailRepository.UpdateOrderDetail(orderDetail);
            return Content("Update success");
        }

        //DELETE: OrderDetailController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int orderId, int productId)
        {
            var OrderDetail = await _OrderDetailRepository.GetOrderDetailByOrderIdProductId(orderId, productId);
            if (OrderDetail == null)
            {
                return NotFound();
            }
            await _OrderDetailRepository.DeleteOrderDetail(orderId, productId);
            return Content("Delete success");
        }

    }
        
}
