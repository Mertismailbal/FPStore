using FPStore.Core.Models;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class CartItemService : GenericService<CartItem>, ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository) : base(cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
        }

        public async Task<CartItem> GetCartItemWithProductAsync(int cartItemId)
        {
            return await _cartItemRepository.GetCartItemWithProductAsync(cartItemId);
        }

        public async Task<CartItem> UpdateQuantityAsync(int cartItemId, int quantity)
        {
            return await _cartItemRepository.UpdateQuantityAsync(cartItemId, quantity);
        }
    }
}
