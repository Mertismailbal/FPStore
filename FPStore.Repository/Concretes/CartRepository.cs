using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace FPStore.Repository.Concretes
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        public CartRepository(DbContext context) : base(context)
        {
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _dbSet.FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<Cart> GetCartWithItemsAsync(string userId)
        {
            return await _dbSet
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.StoreProduct)
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<Cart>> GetActiveCartsAsync()
        {
            return await _dbSet.Where(c => c.IsActive==Core.Enums.Status.Active).ToListAsync();
        }
    }
} 