using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace FPStore.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _transaction;
        private readonly DbContext _context;
        private readonly IProductRepository _products;
        private readonly ICategoryRepository _categories;
        private readonly IOrderRepository _orders;
        private readonly IReviewRepository _reviews;
        private readonly IIdentityRepository _identities;
        private readonly IInvoiceRepository _invoices;
        private readonly IInvoiceItemRepository _invoiceItem;
        private readonly IOrderItemRepository _orderitems;
        private readonly IAddressRepository _addresses;

        public UnitOfWork(IDbContextTransaction transaction, DbContext context, IProductRepository products, ICategoryRepository categories, IOrderRepository orders, IReviewRepository reviews, IIdentityRepository identities, IInvoiceRepository invoices, IInvoiceItemRepository invoiceItem, IOrderItemRepository orderitems, IAddressRepository addresses)
        {
            _transaction = transaction;
            _context = context;
            _products = products;
            _categories = categories;
            _orders = orders;
            _reviews = reviews;
            _identities = identities;
            _invoices = invoices;
            _invoiceItem = invoiceItem;
            _orderitems = orderitems;
            _addresses = addresses;
        }

        public IProductRepository Product => _products;
        public ICategoryRepository Category => _categories;
        public IOrderRepository Order => _orders;
        public IReviewRepository Review => _reviews;
        public IIdentityRepository Identity => _identities;

        public IAddressRepository Address => _addresses;

        public IOrderItemRepository OrderItem => _orderitems;

        public IInvoiceRepository Invoice => _invoices;

        public IInvoiceItemRepository InvoiceItem => _invoiceItem;

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}