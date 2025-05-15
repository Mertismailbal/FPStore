using FPStore.Core.Enums;
using FPStore.Core.Models;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class InvoiceService : GenericService<Invoice>, IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository) : base(invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> GetInvoiceWithItemsAsync(int invoiceId)
        {
            return await _invoiceRepository.GetInvoiceWithItemsAsync(invoiceId);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByUserIdAsync(string userId)
        {
            return await _invoiceRepository.GetInvoicesByUserIdAsync(userId);
        }

        public async Task<Invoice> CreateInvoiceFromOrderAsync(int orderId)
        {
            return await _invoiceRepository.CreateInvoiceFromOrderAsync(orderId);
        }

        public async Task<Invoice> UpdateInvoiceStatusAsync(int invoiceId, InvoiceStatus status)
        {
            return await _invoiceRepository.UpdateInvoiceStatusAsync(invoiceId, status);
        }
    }
} 