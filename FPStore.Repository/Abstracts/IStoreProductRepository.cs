using FPStore.Core.Models.Store;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IStoreProductRepository : IGenericRepository<StoreProduct>
    {
        Task<StoreProduct> GetStoreProductWithDetailsAsync(int storeProductId);
        Task<IEnumerable<StoreProduct>> GetStoreProductsByProductIdAsync(int productId);
        Task<IEnumerable<StoreProduct>> GetActiveStoreProductsAsync();
        Task<StoreProduct> UpdateStockAsync(int storeProductId, int quantity);
    }
} 