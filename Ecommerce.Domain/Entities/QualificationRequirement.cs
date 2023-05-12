using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class QualificationRequirement : BaseEntity
    {
        public int? NumberOfMonths { get; set; } = default(int?);
        public decimal? TotalAmountSpent { get; set; } = default(decimal?);
        public string DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
    }
}
