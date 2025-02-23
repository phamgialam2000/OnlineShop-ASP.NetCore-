using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllOrderDetail();
        Task<OrderDetail> GetOrderDetailByOrderIdProductId(int orderId, int productId);
        Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail);
        Task DeleteOrderDetail(int orderId, int productId);
        Task<IEnumerable<OrderDetail>> GetOrderDetailByOrderId(int orderId);
    }
}
