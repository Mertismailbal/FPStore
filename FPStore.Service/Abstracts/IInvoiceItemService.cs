using FPStore.Core.Entities;

namespace FPStore.Service.Abstracts
{
    public interface IInvoiceItemService : IGenericService<InvoiceItem>
    {
        Task<IEnumerable<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(int invoiceId);
        Task<InvoiceItem> GetInvoiceItemWithProductAsync(int invoiceItemId);
    }
} 