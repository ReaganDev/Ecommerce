using Ecommerce.Domain.Common;
using Ecommerce.Domain.Enums;

namespace Ecommerce.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountName { get; set; }
        public DiscountType DiscountType { get; set; }
        public int Requirement { get; set; }
        public double DiscountPercentage { get; set; }

    }
}
