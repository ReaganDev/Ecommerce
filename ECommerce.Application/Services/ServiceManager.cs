using AutoMapper;
using ECommerce.Application.Contracts;
using ECommerce.Data.Contract;

namespace ECommerce.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;
        private readonly Lazy<IDiscountService> _discountService;
        private readonly Lazy<IRequirementService> _requirementService;

        public ServiceManager(IRepositoryManager repository,
            IMapper mapper)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repository, mapper));
            _discountService = new Lazy<IDiscountService>(() => new DiscountService(repository));
            //_requirementService = new Lazy<IRequirementService>(() => new RequirementService(repository, mapper));
        }

        public ICustomerService CustomerService => _customerService.Value;

        public IDiscountService DiscountService => _discountService.Value;

        public IRequirementService RequirementService => _requirementService.Value;
    }
}
