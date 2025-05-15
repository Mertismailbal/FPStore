using FPStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<OrderItem> GetOrderItemWithProductAsync(int orderItemId);
        Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId);
    }
}
