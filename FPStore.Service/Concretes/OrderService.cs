using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using FPStore.Core.Enums;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FPStore.Service.Concretes
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IStoreProductRepository _storeProductRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            ICartRepository cartRepository,
            IStoreProductRepository storeProductRepository,
            IUnitOfWork unitOfWork) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _storeProductRepository = storeProductRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Order> GetOrderWithItemsAsync(int orderId)
        {
            return await _orderRepository.GetOrderWithItemsAsync(orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _orderRepository.GetOrdersByUserIdAsync(userId);
        }

        public async Task<Order> CreateOrderFromCartAsync(int cartId, string userId)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                // Sepeti al
                var cart = await _cartRepository.GetCartWithItemsAsync(cartId);
                if (cart == null)
                    throw new Exception("Sepet bulunamadı");

                // Stok kontrolü
                foreach (var item in cart.CartItems)
                {
                    var storeProduct = item.StoreProduct;
                    if (storeProduct.Stock < item.Quantity)
                        throw new Exception($"Ürün {storeProduct.Product.Name} için yeterli stok yok. Mevcut stok: {storeProduct.Stock}");
                }

                // Sipariş oluştur
                var order = await _orderRepository.CreateOrderFromCartAsync(cartId, userId);

                // Stokları güncelle
                foreach (var item in cart.CartItems)
                {
                    var storeProduct = item.StoreProduct;
                    storeProduct.Stock -= item.Quantity;
                    await _storeProductRepository.UpdateAsync(storeProduct);
                }

                // Sepeti temizle
                await _cartRepository.DeleteAsync(cart);

                await _unitOfWork.CommitTransactionAsync();
                return order;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task<Order> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            return await _orderRepository.UpdateOrderStatusAsync(orderId, status);
        }
    }
} 