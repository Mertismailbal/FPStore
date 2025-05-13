using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface IInvoiceItemService : IGenericService<InvoiceItem>
    {
        Task<IEnumerable<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(int invoiceId);
        Task<InvoiceItem> GetInvoiceItemWithProductAsync(int invoiceItemId);
    }
}
