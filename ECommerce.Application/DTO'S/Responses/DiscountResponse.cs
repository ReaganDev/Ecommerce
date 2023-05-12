using Ecommerce.Domain.Enums;

namespace ECommerce.Application.DTO_S.Responses
{
    public class DiscountResponse
    {
        public string DiscountName { get; set; }
        public DiscountType DiscountType { get; set; }
        public int? RequiredAmount { get; set; }
        public int? RequiredMonths { get; set; }
        public double DiscountPercentage { get; set; }
    }
}
