using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface ICartService : IGenericService<Cart>
    {
        Task<Cart> GetCartWithItemsAsync(int cartId);
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<Cart> AddItemToCartAsync(int cartId, int productId, int quantity);
        Task<Cart> RemoveItemFromCartAsync(int cartId, int productId);
        Task<Cart> UpdateCartItemQuantityAsync(int cartId, int productId, int quantity);
    }

}
