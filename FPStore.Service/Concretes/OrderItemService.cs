using FPStore.Core.Entities;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class OrderItemService : GenericService<OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository) : base(orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemsByOrderIdAsync(int orderId)
        {
            return await _orderItemRepository.GetOrderItemsByOrderIdAsync(orderId);
        }

        public async Task<OrderItem> GetOrderItemWithProductAsync(int orderItemId)
        {
            return await _orderItemRepository.GetOrderItemWithProductAsync(orderItemId);
        }
    }
} 