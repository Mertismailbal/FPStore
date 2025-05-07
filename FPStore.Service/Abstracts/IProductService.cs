using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsWithReviewsAsync();
        Task<Product> GetProductWithDetailsAsync(int productId);
    }
} 