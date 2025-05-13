using FPStore.Core.Enums;
using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> CreateOrderFromCartAsync(int cartId, string userId);
        Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus status);
    }
}
