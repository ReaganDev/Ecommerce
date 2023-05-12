using Ecommerce.Domain.Entities;
using ECommerce.Data.Contract;

namespace ECommerce.Data.Repository
{
    public class RequirementRepository : Repository<QualificationRequirement>, IRequirementRepository
    {
        public RequirementRepository(ECommerceContext context) : base(context)
        {

        }
    }
}
