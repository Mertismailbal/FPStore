using FPStore.Core.Models;
using FPStore.Core.Models.Identity;
using System;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Address { get; }
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        IOrderRepository Order { get; }
        IOrderItemRepository OrderItem { get; }
        IInvoiceRepository Invoice { get; }
        IInvoiceItemRepository InvoiceItem { get; }
        IReviewRepository Review { get; }
        IIdentityRepository Identity { get; }//Bundan emin deðiliz düzeltilmeli;

        Task<int> Save();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
} 