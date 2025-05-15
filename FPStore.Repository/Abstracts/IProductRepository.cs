using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        // Product'a özel metodlar buraya eklenir
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> GetProductsWithReviewsAsync();
        Task<Product> GetProductWithDetailsAsync(int productId);
        //Task<IEnumerable<Product>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task UpdateAsync(Product product);
    }
} 