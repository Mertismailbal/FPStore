using FPStore.Core.Models;

namespace FPStore.Servicee.Abstracts
{
    public interface IInvoiceService : IGenericService<Invoice>
    {
        Task<Invoice> GetInvoiceWithItemsAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetInvoicesByUserIdAsync(string userId);
        Task<Invoice> CreateInvoiceFromOrderAsync(int orderId);
        Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus status);
    }
}
