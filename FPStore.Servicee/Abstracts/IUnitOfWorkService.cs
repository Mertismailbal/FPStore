namespace FPStore.Servicee.Abstracts
{
    public interface IUnitOfWorkService
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        ICartService CartService { get; }
        ICartItemService CartItemService { get; }
        IOrderService OrderService { get; }
        IOrderItemService OrderItemService { get; }
        IInvoiceService InvoiceService { get; }
        IInvoiceItemService InvoiceItemService { get; }
        IReviewService ReviewService { get; }
        IAddressService AddressService { get; }
        IIdentityService IdentityService { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
