using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface IReviewService : IGenericService<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId);
        Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId);
        Task<double> GetAverageRatingForProductAsync(int productId);
    }
} 