using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class ProductService : GenericService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _productRepository.GetProductsByCategoryAsync(categoryId);
        }

        public async Task<IEnumerable<Product>> GetProductsWithReviewsAsync()
        {
            return await _productRepository.GetProductsWithReviewsAsync();
        }

        public async Task<Product> GetProductWithDetailsAsync(int productId)
        {
            return await _productRepository.GetProductWithDetailsAsync(productId);
        }

        public async Task UpdateAsync(Product product)
        {
            await _productRepository.UpdateAsync(product);
        }
    }
} 