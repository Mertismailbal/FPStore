using FPStore.Repository.Abstracts;
using FPStore.Service.Abstracts;

namespace FPStore.Service.Concretes
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ICartService _cartService;
        private readonly ICartItemService _cartItemService;
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceItemService _invoiceItemService;
        private readonly IReviewService _reviewService;
        private readonly IAddressService _addressService;
        private readonly IIdentityService _identityService;

        public UnitOfWorkService(
            IUnitOfWork unitOfWork,
            IProductService productService,
            ICategoryService categoryService,
            ICartService cartService,
            ICartItemService cartItemService,
            IOrderService orderService,
            IOrderItemService orderItemService,
            IInvoiceService invoiceService,
            IInvoiceItemService invoiceItemService,
            IReviewService reviewService,
            IAddressService addressService,
            IIdentityService identityService)
        {
            _unitOfWork = unitOfWork;
            _productService = productService;
            _categoryService = categoryService;
            _cartService = cartService;
            _cartItemService = cartItemService;
            _orderService = orderService;
            _orderItemService = orderItemService;
            _invoiceService = invoiceService;
            _invoiceItemService = invoiceItemService;
            _reviewService = reviewService;
            _addressService = addressService;
            _identityService = identityService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _categoryService;
        public ICartService CartService => _cartService;
        public ICartItemService CartItemService => _cartItemService;
        public IOrderService OrderService => _orderService;
        public IOrderItemService OrderItemService => _orderItemService;
        public IInvoiceService InvoiceService => _invoiceService;
        public IInvoiceItemService InvoiceItemService => _invoiceItemService;
        public IReviewService ReviewService => _reviewService;
        public IAddressService AddressService => _addressService;
        public IIdentityService IdentityService => _identityService;

        public async Task<int> SaveChangesAsync()
        {
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _unitOfWork.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _unitOfWork.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _unitOfWork.RollbackTransactionAsync();
        }
    }
} 