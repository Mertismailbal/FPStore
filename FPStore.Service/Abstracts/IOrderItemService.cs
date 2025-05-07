using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface IOrderItemService : IGenericService<OrderItem>
    {
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
        Task<OrderItem> GetOrderItemWithProductAsync(int orderItemId);
    }
} 