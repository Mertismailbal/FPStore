using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Category'e özel metodlar buraya eklenir
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
} 