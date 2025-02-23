using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class OrderDAO : SingletonBase<OrderDAO>
    {
        public async Task<IEnumerable<Order>> GetOrderAll()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(c => c.OrderId == id);
            if (order == null) return null;
            return order;
        }
        public async Task<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<Order> UpdateOrder(Order order)
        {
            var existingOrder = await GetOrderById(order.OrderId);
            if (existingOrder != null)
            {
                _context.Entry(existingOrder).CurrentValues.SetValues(order);
            }
            else
            {
                _context.Orders.Add(order);

            }
            await _context.SaveChangesAsync();
            return order;
        }
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await GetOrderById(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}