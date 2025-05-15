using FPStore.Core.Models;
using FPStore.Core.Enums;

namespace FPStore.Service.Abstracts
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> CreateOrderFromCartAsync(int cartId, string userId);
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus status);
    }
} 