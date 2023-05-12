using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public DateTime DateJoined { get; set; }
        public string? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

    }
}
