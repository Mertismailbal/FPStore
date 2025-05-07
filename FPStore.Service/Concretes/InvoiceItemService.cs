using FPStore.Core.Entities;
using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class InvoiceItemService : GenericService<InvoiceItem>, IInvoiceItemService
    {
        private readonly IInvoiceItemRepository _invoiceItemRepository;

        public InvoiceItemService(IInvoiceItemRepository invoiceItemRepository) : base(invoiceItemRepository)
        {
            _invoiceItemRepository = invoiceItemRepository;
        }

        public async Task<IEnumerable<InvoiceItem>> GetInvoiceItemsByInvoiceIdAsync(int invoiceId)
        {
            return await _invoiceItemRepository.GetInvoiceItemsByInvoiceIdAsync(invoiceId);
        }

        public async Task<InvoiceItem> GetInvoiceItemWithProductAsync(int invoiceItemId)
        {
            return await _invoiceItemRepository.GetInvoiceItemWithProductAsync(invoiceItemId);
        }
    }
} 