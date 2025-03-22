using FPStore.Core.Models;
using FPStore.Core.Models.Identity;
using System;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IOrderRepository Orders { get; }
        IReviewRepository Reviews { get; }
        IIdentityRepository Identity { get; }//Bundan emin deðiliz düzeltilmeli;
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 