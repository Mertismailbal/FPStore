using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
} 