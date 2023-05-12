using ECommerce.Application.DTO_S.Requests;
using ECommerce.Application.Helpers;

namespace ECommerce.Application.Contracts
{
    public interface IDiscountService
    {
        Task<SuccessResponse<string>> CreateDiscount(CreateDiscount request);
    }
}
