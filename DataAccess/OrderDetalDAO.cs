using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDetailDAO : SingletonBase<OrderDetailDAO>
    {
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailAll()
        {
            return await _context.OrderDetails.ToListAsync();
        }
        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId)
        {
            var orderDetail = await _context.OrderDetails.FirstOrDefaultAsync(c => c.OrderId == orderId && c.ProductId == productId);
            if (orderDetail == null) return null;
            return orderDetail;
        }
        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int orderId)
        {
            var orderDetail = await _context.OrderDetails.Where(c => c.OrderId == orderId).ToListAsync();
            if (orderDetail == null) return null;
            return orderDetail;
        }
        public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
        {
            _context.OrderDetails.Add(orderDetail);
            await _context.SaveChangesAsync();
            return orderDetail;
        }
        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail = await GetOrderDetailByOrderIdProductId(orderDetail.OrderId, orderDetail.ProductId);
            if (existingOrderDetail != null)
            {
                _context.Entry(existingOrderDetail).CurrentValues.SetValues(orderDetail);
            }
            await _context.SaveChangesAsync();
            return orderDetail;
        }
        public async Task<bool> DeleteOrderDetail(int orderId, int productId)
        {
            var orderDetail = await GetOrderDetailByOrderIdProductId(orderId,productId);
            if (orderDetail == null) return false;
            _context.OrderDetails.Remove(orderDetail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}