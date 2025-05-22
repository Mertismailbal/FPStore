using FPStore.Core.Enums;
using FPStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPStore.Repository.Abstracts
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<Invoice> GetInvoiceWithItemsAsync(int invoiceId);
        Task<IEnumerable<Invoice>> GetInvoicesByUserIdAsync(string userId);
        Task<Invoice> CreateInvoiceFromOrderAsync(int orderId);
        Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus status);
    }
}
