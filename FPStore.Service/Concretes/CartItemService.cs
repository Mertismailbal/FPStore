using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPStore.Service.Concretes
{
    public class CartItemService : GenericService<CartItem>, ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository) : base(cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<List<CartItem>> GetCartItemsByUserIdAsync(string userId)
        {
            return await _cartItemRepository.GetCartItemsByUserIdAsync(userId);
        }

        public async Task<CartItem> GetCartItemWithProductAsync(int cartItemId)
        {
            // Implementasyon örneği
            return null;
        }

        public async Task<CartItem> UpdateQuantityAsync(int cartItemId, int quantity)
        {
            // Implementasyon örneği
            return null;
        }
    }
} 