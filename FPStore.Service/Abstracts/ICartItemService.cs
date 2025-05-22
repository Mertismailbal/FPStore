using FPStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPStore.Service.Abstracts
{
    public interface ICartItemService : IGenericService<CartItem>
    {
        Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId);
        Task<CartItem> GetCartItemWithProductAsync(int cartItemId);
        Task<CartItem> UpdateQuantityAsync(int cartItemId, int quantity);
    }
} 