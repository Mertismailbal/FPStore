using FPStore.Core.Enums;
using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class OrderService : GenericService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork) : base(orderRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
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
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    if (product.Stock < item.Quantity)
                        throw new Exception($"Ürün {product.Name} için yeterli stok yok. Mevcut stok: {product.Stock}");
                }

                // Sipariş oluştur
                var order = await _orderRepository.CreateOrderFromCartAsync(cartId, userId);

                // Stokları güncelle
                foreach (var item in cart.CartItems)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    product.Stock -= item.Quantity;
                    await _productRepository.UpdateAsync(product);
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
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                var order = await _orderRepository.GetOrderWithItemsAsync(orderId);
                if (order == null)
                    throw new Exception("Sipariş bulunamadı");

                // İptal durumunda stokları geri ekle
                if (status == OrderStatus.Cancelled && order.Status != OrderStatus.Cancelled)
                {
                    foreach (var item in order.OrderItems)
                    {
                        var product = await _productRepository.GetByIdAsync(item.ProductId);
                        product.Stock += item.Quantity;
                        await _productRepository.UpdateAsync(product);
                    }
                }

                order = await _orderRepository.UpdateOrderStatusAsync(orderId, status);

                await _unitOfWork.CommitTransactionAsync();
                return order;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
    }
}
