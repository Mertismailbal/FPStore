using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface ICartItemService : IGenericService<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        Task<CartItem> GetCartItemWithProductAsync(int cartItemId);
        Task<CartItem> UpdateQuantityAsync(int cartItemId, int quantity);
    }


}
