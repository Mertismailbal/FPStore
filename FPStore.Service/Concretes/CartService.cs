using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FPStore.Service.Concretes
{
    public class CartService : GenericService<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IStoreProductRepository _storeProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(
            ICartRepository cartRepository,
            IStoreProductRepository storeProductRepository,
            IUnitOfWork unitOfWork) : base(cartRepository)
        {
            _cartRepository = cartRepository;
            _storeProductRepository = storeProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Cart> GetCartWithItemsAsync(int cartId)
        {
            return await _cartRepository.GetCartWithItemsAsync(cartId);
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId)
        {
            return await _cartRepository.GetCartByUserIdAsync(userId);
        }

        public async Task<Cart> AddItemToCartAsync(int cartId, int storeProductId, int quantity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Stok kontrolü
                var storeProduct = await _storeProductRepository.GetByIdAsync(storeProductId);
                if (storeProduct == null)
                    throw new Exception("Ürün mağazada bulunamadı");

                if (storeProduct.Stock < quantity)
                    throw new Exception($"Yeterli stok yok. Mevcut stok: {storeProduct.Stock}");

                // Sepete ekle
                var cart = await _cartRepository.AddItemToCartAsync(cartId, storeProductId, quantity);

                // Stok güncelle
                storeProduct.Stock -= quantity;
                await _storeProductRepository.UpdateAsync(storeProduct);

                await _unitOfWork.CommitTransactionAsync();
                return cart;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Cart> RemoveItemFromCartAsync(int cartId, int storeProductId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Sepetten ürünü al
                var cart = await _cartRepository.GetCartWithItemsAsync(cartId);
                var cartItem = cart.CartItems.FirstOrDefault(x => x.StoreProductId == storeProductId);
                
                if (cartItem != null)
                {
                    // Stok geri ekle
                    var storeProduct = await _storeProductRepository.GetByIdAsync(storeProductId);
                    if (storeProduct != null)
                    {
                        storeProduct.Stock += cartItem.Quantity;
                        await _storeProductRepository.UpdateAsync(storeProduct);
                    }
                }

                // Sepetten kaldır
                cart = await _cartRepository.RemoveItemFromCartAsync(cartId, storeProductId);

                await _unitOfWork.CommitTransactionAsync();
                return cart;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Cart> UpdateCartItemQuantityAsync(int cartId, int storeProductId, int quantity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Mevcut sepet ürününü al
                var cart = await _cartRepository.GetCartWithItemsAsync(cartId);
                var cartItem = cart.CartItems.FirstOrDefault(x => x.StoreProductId == storeProductId);
                
                if (cartItem != null)
                {
                    var storeProduct = await _storeProductRepository.GetByIdAsync(storeProductId);
                    if (storeProduct != null)
                    {
                        // Stok kontrolü
                        if (storeProduct.Stock < quantity)
                            throw new Exception($"Yeterli stok yok. Mevcut stok: {storeProduct.Stock}");

                        // Eski miktarı stoka geri ekle
                        storeProduct.Stock += cartItem.Quantity;
                        
                        // Yeni miktarı stoktan düş
                        storeProduct.Stock -= quantity;
                        await _storeProductRepository.UpdateAsync(storeProduct);
                    }
                }

                // Sepeti güncelle
                cart = await _cartRepository.UpdateCartItemQuantityAsync(cartId, storeProductId, quantity);

                await _unitOfWork.CommitTransactionAsync();
                return cart;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
} 