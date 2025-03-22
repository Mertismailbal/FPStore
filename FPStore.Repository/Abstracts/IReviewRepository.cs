using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId);
        Task<double> GetAverageRatingForProductAsync(int productId);
    }
} 