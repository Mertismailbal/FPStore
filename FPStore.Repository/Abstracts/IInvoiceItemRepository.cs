using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPStore.Core.Models;

namespace FPStore.Repository.Abstracts
{
    public interface IInvoiceItemRepository : IGenericRepository<InvoiceItem>
    {
        Task<IEnumerable<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(int invoiceId);
        Task<InvoiceItem> GetInvoiceItemWithProductAsync(int invoiceItemId);
    }
}
