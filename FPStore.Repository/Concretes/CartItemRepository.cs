using FPStore.Core.Enums;
using FPStore.Core.Models;
using FPStore.Core.Models.Identity;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DbContext context) : base(context)
        {
        }

        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId)
        {
            return await _dbSet
                .Include(ci => ci.StoreProduct)
                .Include(ci => ci.Cart)
                .Where(ci => ci.Cart.UserId == userId && ci.Cart.Status == Core.Enums.Status.Active)
                .ToListAsync();
        }

    }
}
