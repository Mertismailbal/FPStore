using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FPStore.Repository.Concretes
{
    public class InvoiceItemRepository : GenericRepository<InvoiceItem>, IInvoiceItemRepository
    {
        private readonly ApplicationDbContext _context;

        public InvoiceItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(int invoiceId)
        {
            return await _context.InvoiceItems
                .Where(ii => ii.InvoiceId == invoiceId)
                .ToListAsync();
        }

        public async Task<InvoiceItem> GetInvoiceItemWithProductAsync(int invoiceItemId)
        {
            return await _context.InvoiceItems
                .FirstOrDefaultAsync(ii => ii.Id == invoiceItemId);
        }
    }
} 