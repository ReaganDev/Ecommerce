using ECommerce.Data.Contract;

namespace ECommerce.Data.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ECommerceContext _context;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IRequirementRepository> _requirementRepository;
        private readonly Lazy<IDiscountRepository> _discountRepository;


        public RepositoryManager(ECommerceContext context)
        {
            _context = context;
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(context));
            _requirementRepository = new Lazy<IRequirementRepository>(() => new RequirementRepository(context));
            _discountRepository = new Lazy<IDiscountRepository>(() => new DiscountRepository(context));
        }
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IRequirementRepository RequirementRepository => _requirementRepository.Value;

        public IDiscountRepository DiscountRepository => _discountRepository.Value;
    }
}
