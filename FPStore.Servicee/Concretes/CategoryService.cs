using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Servicee.Abstracts;

namespace FPStore.Servicee.Concretes
{
    public class CategoryService : GenericService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        {
            return await _categoryRepository.GetCategoriesWithProductsAsync();
        }

        public async Task<Category> GetCategoryWithProductsAsync(int categoryId)
        {
            return await _categoryRepository.GetCategoryWithProductsAsync(categoryId);
        }
    }

}
