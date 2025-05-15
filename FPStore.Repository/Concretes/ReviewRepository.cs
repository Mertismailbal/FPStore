using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FPStore.Repository.Concretes
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.StoreProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsByUserIdAsync(string userId)
        {
            return await _context.Reviews
                .Where(r => r.MemberId == int.Parse(userId))
                .ToListAsync();
        }

        public async Task<double> GetAverageRatingForProductAsync(int productId)
        {
            return await _context.Reviews
                .Where(r => r.StoreProductId == productId && r.Rating.HasValue)
                .AverageAsync(r => r.Rating.Value);
        }
    }
} 