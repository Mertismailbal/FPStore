using FPStore.Core.Entities;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
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