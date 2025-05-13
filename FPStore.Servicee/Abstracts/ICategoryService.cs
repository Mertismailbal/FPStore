using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesWithProductsAsync();
        Task<Category> GetCategoryWithProductsAsync(int categoryId);
    }
}
