using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Cart> GetCartWithItemsAsync(int cartId)
        {
            return await _dbSet
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.StoreProduct)
                .FirstOrDefaultAsync(c => c.Id == cartId);
        }

        public async Task<IEnumerable<Cart>> GetActiveCartsAsync()
        {
            return await _dbSet.Where(c => c.IsActive == Core.Enums.Status.Active).ToListAsync();
        }

        public async Task<Cart> AddItemToCartAsync(int cartId, int storeProductId, int quantity)
        {
            var cart = await GetCartWithItemsAsync(cartId);
            if (cart == null)
                throw new Exception("Sepet bulunamadı");

            var existingItem = cart.CartItems.FirstOrDefault(ci => ci.StoreProductId == storeProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem
                {
                    CartId = cartId,
                    StoreProductId = storeProductId,
                    Quantity = quantity
                });
            }

            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<Cart> RemoveItemFromCartAsync(int cartId, int storeProductId)
        {
            var cart = await GetCartWithItemsAsync(cartId);
            if (cart == null)
                throw new Exception("Sepet bulunamadı");

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.StoreProductId == storeProductId);
            if (cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task<Cart> UpdateCartItemQuantityAsync(int cartId, int storeProductId, int quantity)
        {
            var cart = await GetCartWithItemsAsync(cartId);
            if (cart == null)
                throw new Exception("Sepet bulunamadı");

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.StoreProductId == storeProductId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                await _context.SaveChangesAsync();
            }

            return cart;
        }

        public async Task DeleteAsync(Cart cart)
        {
            _dbSet.Remove(cart);
            await _context.SaveChangesAsync();
        }
    }
} 