using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPStore.Core.Enums;

namespace FPStore.Repository.Concretes
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(DbContext context) : base(context)
        {
        }

        public async Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, FPStore.Core.Enums.InvoiceStatus status)
        {
            // TODO: Implement
            return await Task.FromResult<Invoice>(null);
        }

        public async Task<Invoice> GetInvoiceWithItemsAsync(int invoiceId)
        {
            // TODO: Implement
            return await Task.FromResult<Invoice>(null);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByUserIdAsync(string userId)
        {
            // TODO: Implement
            return await Task.FromResult<IEnumerable<Invoice>>(null);
        }

        public async Task<Invoice> CreateInvoiceFromOrderAsync(int orderId)
        {
            // TODO: Implement
            return await Task.FromResult<Invoice>(null);
        }
    }
}
