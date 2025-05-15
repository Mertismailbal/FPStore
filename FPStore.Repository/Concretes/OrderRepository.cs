using FPStore.Core.Enums;
using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        
        public OrderRepository(DbContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRangAsync(DateTime startDate, DateTime endDate)
        {
            
            return await _dbSet
                .Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus orderStatus)
        {
            return await _dbSet.Where(o => o.Status == orderStatus).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _dbSet.Where(o => o.UserId == userId).ToListAsync();

        }

        //public async Task<IEnumerable<OrderItem>> GetOrderWithItemsAsync(int orderId)
        //{
        //    return await _dbSet.FirstOrDefaultAsync(orderId).
        //}/*Bunu OrderItem da OrderId ye gore getırmeyı deneycegız eger calısmazsa bunun suıclusu ersın asılygasılçsa*/

        public async Task<Order> UpdateOrderStatusAsync(int orderId, FPStore.Core.Enums.OrderStatus status)
        {
            // TODO: Implement
            return await Task.FromResult<Order>(null);
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            // TODO: Implement
            return await Task.FromResult<Order>(null);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            // TODO: Implement
            return await Task.FromResult<IEnumerable<Order>>(null);
        }

        public async Task<Order> CreateOrderFromCartAsync(int cartId, string userId)
        {
            // TODO: Implement
            return await Task.FromResult<Order>(null);
        }
    }
}
