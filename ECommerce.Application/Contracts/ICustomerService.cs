using Ecommerce.Domain.Entities;
using ECommerce.Application.DTO_S.Requests;
using ECommerce.Application.Helpers;

namespace ECommerce.Application.Contracts
{
    public interface ICustomerService
    {
        Task<SuccessResponse<string>> CreateCustomer(CreateCustomer request);
        Task<SuccessResponse<List<Discount>>> ProfileCustomer(string phoneNumber);
        Task<SuccessResponse<string>> UpdateCustomer(string phoneNumber, UpdateCustomer request);
    }
}
