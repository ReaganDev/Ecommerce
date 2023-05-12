namespace ECommerce.Application.Contracts
{
    public interface IServiceManager
    {
        ICustomerService CustomerService { get; }
        IDiscountService DiscountService { get; }
        IRequirementService RequirementService { get; }
    }
}
