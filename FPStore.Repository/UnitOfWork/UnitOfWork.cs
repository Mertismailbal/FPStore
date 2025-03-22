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

        public UnitOfWork(IDbContextTransaction transaction, DbContext context, IProductRepository products, ICategoryRepository categories, IOrderRepository order, IReviewRepository reviews, IIdentityRepository identities)
        {
            _transaction = transaction;
            _context = context;
            _products = products;
            _categories = categories;
            _orders = order;
            _reviews = reviews;
            _identities = identities;
        }
        public IProductRepository Products => _products;
        public ICategoryRepository Categories => _categories;
        public IOrderRepository Orders => _orders;
        public IReviewRepository Reviews => _reviews;
        public IIdentityRepository Identity => _identities;

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