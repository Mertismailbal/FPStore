using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DbContext context) : base(context)
        {
        }

        public async Task<OrderItem> GetOrderItemWithProductAsync(int orderItemId)
        {
            return await _dbSet
                .Include(oi => oi.StoreProduct)
                .FirstOrDefaultAsync(oi => oi.Id == orderItemId);
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _dbSet
                .Include(oi => oi.StoreProduct)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }
    }
}
