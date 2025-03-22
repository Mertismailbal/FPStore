using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId);
        Task<Order> GetOrderWithItemsAsync(int orderId);
        Task<IEnumerable<Order>> eGetOrdersByStatusAsync(string status);
        Task<IEnumerable<Order>> GetOrdersByDateRangAsync(DateTime startDate, DateTime endDate);
    }
} 