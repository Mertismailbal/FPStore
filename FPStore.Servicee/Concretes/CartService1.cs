using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class CartService : GenericService<Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork) : base(cartRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
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

        public async Task<Cart> AddItemToCartAsync(int cartId, int productId, int quantity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Stok kontrolü
                var product = await _productRepository.GetByIdAsync(productId);
                if (product == null)
                    throw new Exception("Ürün bulunamadı");

                if (product.Stock < quantity)
                    throw new Exception($"Yeterli stok yok. Mevcut stok: {product.Stock}");

                // Sepete ekle
                var cart = await _cartRepository.AddItemToCartAsync(cartId, productId, quantity);

                // Stok güncelle
                product.Stock -= quantity;
                await _productRepository.UpdateAsync(product);

                await _unitOfWork.CommitTransactionAsync();
                return cart;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Cart> RemoveItemFromCartAsync(int cartId, int productId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Sepetten ürünü al
                var cart = await _cartRepository.GetCartWithItemsAsync(cartId);
                var cartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

                if (cartItem != null)
                {
                    // Stok geri ekle
                    var product = await _productRepository.GetByIdAsync(productId);
                    product.Stock += cartItem.Quantity;
                    await _productRepository.UpdateAsync(product);
                }

                // Sepetten kaldır
                cart = await _cartRepository.RemoveItemFromCartAsync(cartId, productId);

                await _unitOfWork.CommitTransactionAsync();
                return cart;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Cart> UpdateCartItemQuantityAsync(int cartId, int productId, int quantity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Mevcut sepet ürününü al
                var cart = await _cartRepository.GetCartWithItemsAsync(cartId);
                var cartItem = cart.CartItems.FirstOrDefault(x => x.ProductId == productId);

                if (cartItem != null)
                {
                    var product = await _productRepository.GetByIdAsync(productId);

                    // Stok kontrolü
                    if (product.Stock < quantity)
                        throw new Exception($"Yeterli stok yok. Mevcut stok: {product.Stock}");

                    // Eski miktarı stoka geri ekle
                    product.Stock += cartItem.Quantity;

                    // Yeni miktarı stoktan düş
                    product.Stock -= quantity;
                    await _productRepository.UpdateAsync(product);
                }

                // Sepeti güncelle
                cart = await _cartRepository.UpdateCartItemQuantityAsync(cartId, productId, quantity);

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
