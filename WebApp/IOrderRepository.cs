using WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Repository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrdersByUserId(int id);
        Task<Order> GetOrder(int id);
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Order order);
        Task<bool> DeleteOrder(int id);
    }
}
