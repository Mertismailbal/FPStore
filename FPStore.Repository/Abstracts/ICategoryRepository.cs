using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // Category'e özel metodlar buraya eklenir
        Task<IEnumerable<Category>> GetActiveCategoriesAsync();
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
} 