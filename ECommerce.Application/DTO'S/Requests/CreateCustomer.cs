namespace ECommerce.Application.DTO_S.Requests
{
    public class CreateCustomer
    {
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public decimal TotalAmountSpent { get; set; }
        public DateTime DateJoined { get; set; }
    }

    public class UpdateCustomer
    {
        public DateTime DateJoined { get; set; }
        public decimal TotalAmountSpent { get; set; }
    }
}
