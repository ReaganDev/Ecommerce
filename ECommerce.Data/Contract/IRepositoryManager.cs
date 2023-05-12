namespace ECommerce.Data.Contract
{
    public interface IRepositoryManager
    {
        ICustomerRepository CustomerRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        IRequirementRepository RequirementRepository { get; }

        Task<int> SaveChangesAsync();

    }
}
