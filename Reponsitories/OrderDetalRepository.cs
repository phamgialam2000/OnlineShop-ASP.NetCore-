using BusinessObjects;
using DataAccess;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
        {
            await OrderDetailDAO.Instance.AddOrderDetail(orderDetail);
            return orderDetail;
        }

        public async Task DeleteOrderDetail(int orderId, int productId)
        {
            await OrderDetailDAO.Instance.DeleteOrderDetail(orderId, productId);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetail()
        {
            return await OrderDetailDAO.Instance.GetOrderDetailAll();
        }

        public async Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId)
        {
            return await OrderDetailDAO.Instance.GetOrderDetailByOrderIdProductId(orderId, productId);
        }

        public Task<OrderDetail> UpdateOrderDetail(OrderDetail OrderDetail)
        {
            return OrderDetailDAO.Instance.UpdateOrderDetail(OrderDetail);
        }

        public async Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int orderId)
        {
             return await OrderDetailDAO.Instance.GetOrderDetailByOrderId(orderId);
        }
    }
}
