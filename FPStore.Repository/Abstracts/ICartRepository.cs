using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartWithItemsAsync(int cartId);
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<Cart> AddItemToCartAsync(int cartId, int storeProductId, int quantity);
        Task<Cart> RemoveItemFromCartAsync(int cartId, int storeProductId);
        Task<Cart> UpdateCartItemQuantityAsync(int cartId, int storeProductId, int quantity);
        Task<IEnumerable<Cart>> GetActiveCartsAsync();
        Task DeleteAsync(Cart cart);
    }
} 