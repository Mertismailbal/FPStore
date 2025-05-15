using FPStore.Core.Enums;
using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> CreateOrderFromCartAsync(int cartId, string userId);
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus status);
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus orderStatus);
        Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
} 