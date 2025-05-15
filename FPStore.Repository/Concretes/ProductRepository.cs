using FPStore.Core.Enums;
using FPStore.Core.Models;
using FPStore.Core.Models.Store;
using FPStore.Repository.Abstracts;
using FPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace FPStore.Repository.Concretes
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _dbSet.Where(p => p.IsActive==Status.Active).ToListAsync();
        }

        //public async Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(double minPrice, double maxPrice)
        //{
        //    AppDbContext db = new AppDbContext();
        //    var products = await db.Products
        //        .Include(p => p.StoreProducts)
        //        .ToListAsync();

        //    var filtered = products
        //        .Where(p => p.StoreProducts.Any(sp => sp.Price >= minPrice && sp.Price <= maxPrice))
        //        .ToList();
        //    return filtered;
        //}

        public async Task UpdateAsync(Product product)
        {
            _dbSet.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductWithDetailsAsync(int productId)
        {
            // TODO: Implement
            return await Task.FromResult<Product>(null);
        }

        public async Task<IEnumerable<Product>> GetProductsWithReviewsAsync()
        {
            // TODO: Implement
            return await Task.FromResult<IEnumerable<Product>>(null);
        }
    }
} 