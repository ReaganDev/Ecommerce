using Ecommerce.Domain.Entities;
using ECommerce.Data.Contract;

namespace ECommerce.Data.Repository
{
    public class DiscountRepository : Repository<Discount>, IDiscountRepository
    {
        public DiscountRepository(ECommerceContext context) : base(context)
        {

        }
    }
}
