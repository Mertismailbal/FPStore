using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class ReviewService : GenericService<Review>, IReviewService
    {
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IReviewRepository reviewRepository) : base(reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _reviewRepository.GetReviewsByProductIdAsync(productId);
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId)
        {
            return await _reviewRepository.GetReviewsByUserIdAsync(userId);
        }

        public async Task<double> GetAverageRatingForProductAsync(int productId)
        {
            return await _reviewRepository.GetAverageRatingForProductAsync(productId);
        }
    }

}
