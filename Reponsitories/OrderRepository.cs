using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<Order> AddOrder(Order order)
        {
            await OrderDAO.Instance.AddOrder(order);
            return order;
        }

        public async Task DeleteOrder(int id)
        {
            await OrderDAO.Instance.DeleteOrder(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrder()
        {
            return await OrderDAO.Instance.GetOrderAll();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await OrderDAO.Instance.GetOrderById(id);
        }

        public Task<Order> UpdateOrder(Order order)
        {
            return OrderDAO.Instance.UpdateOrder(order);
        }
    }
}
