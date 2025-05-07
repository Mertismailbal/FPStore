using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface ICartItemService : IGenericService<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
        Task<CartItem> GetCartItemWithProductAsync(int cartItemId);
        Task<CartItem> UpdateQuantityAsync(int cartItemId, int quantity);
    }
} 