using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task<IEnumerable<Cart>> GetActiveCartsAsync();
    }
} 