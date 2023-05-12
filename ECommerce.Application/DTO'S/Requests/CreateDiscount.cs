using Ecommerce.Domain.Enums;

namespace ECommerce.Application.DTO_S.Requests
{
    public class CreateDiscount
    {
        public string DiscountName { get; set; }
        public Requirement? RequiredMonths { get; set; }
        public RequirementAmount? RequiredAmount { get; set; }
        public DiscountType DiscountType { get; set; }
        public double DiscountPercentage { get; set; }
    }


}
