using Ecommerce.Domain.Entities;
using ECommerce.Data.Contract;

namespace ECommerce.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ECommerceContext context) : base(context)
        {

        }
    }
}
