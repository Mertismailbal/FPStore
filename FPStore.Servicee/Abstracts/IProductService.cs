using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface IProductService : IGenericService<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsWithReviewsAsync();
        Task<Product> GetProductWithDetailsAsync(int productId);
    }
}
