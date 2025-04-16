using FPStore.Core.Enums;
using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        //Task<IEnumerable<OrderItem>> GetOrderWithItemsAsync(int orderId);Ersýn yuzunden oluyor bunlar
        Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus orderOtatus);
        Task<IEnumerable<Order>> GetOrdersByDateRangAsync(DateTime startDate, DateTime endDate);
    }
} 