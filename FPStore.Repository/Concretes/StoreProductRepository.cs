using FPStore.Core.Models.Store;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class StoreProductRepository : GenericRepository<StoreProduct>, IStoreProductRepository
    {
        public StoreProductRepository(DbContext context) : base(context)
        {
        }

        public async Task<StoreProduct> GetStoreProductWithDetailsAsync(int storeProductId)
        {
            return await _dbSet
                .Include(sp => sp.Product)
                .FirstOrDefaultAsync(sp => sp.Id == storeProductId);
        }

        public async Task<IEnumerable<StoreProduct>> GetStoreProductsByProductIdAsync(int productId)
        {
            return await _dbSet
                .Where(sp => sp.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StoreProduct>> GetActiveStoreProductsAsync()
        {
            return await _dbSet
                .Where(sp => sp.IsActive == Core.Enums.Status.Active)
                .ToListAsync();
        }

        public async Task<StoreProduct> UpdateStockAsync(int storeProductId, int quantity)
        {
            var storeProduct = await _dbSet.FindAsync(storeProductId);
            if (storeProduct != null)
            {
                storeProduct.Stock = quantity;
                await _context.SaveChangesAsync();
            }
            return storeProduct;
        }
    }
} 