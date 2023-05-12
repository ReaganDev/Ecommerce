using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTO_S.Requests;
using ECommerce.Application.Helpers;
using ECommerce.Data.Contract;
using System.Net;

namespace ECommerce.Application.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepositoryManager _repository;

        public DiscountService(IRepositoryManager repository)
        {
            _repository = repository;
        }


        public async Task<SuccessResponse<string>> CreateDiscount(CreateDiscount request)
        {
            var discount = new Discount();

            if (request.DiscountType == DiscountType.AmountSpent && request.RequiredAmount == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, ResponseMessages.BadRequest);
            }
            else if (request.DiscountType == DiscountType.AmountSpent && request.RequiredAmount != null)
            {
                discount.DiscountName = request.DiscountName;
                discount.DiscountPercentage = request.DiscountPercentage;
                discount.DiscountType = request.DiscountType;
                discount.Requirement = (int)request.RequiredAmount;
            }

            if (request.DiscountType == DiscountType.MonthBased && request.RequiredMonths == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, ResponseMessages.BadRequest);
            }
            else if (request.DiscountType == DiscountType.MonthBased && request.RequiredMonths != null)
            {
                discount.DiscountName = request.DiscountName;
                discount.DiscountPercentage = request.DiscountPercentage;
                discount.DiscountType = request.DiscountType;
                discount.Requirement = (int)request.RequiredMonths;
            }

            await _repository.DiscountRepository.CreateAsync(discount);
            await _repository.SaveChangesAsync();

            return new SuccessResponse<string>
            {
                Message = ResponseMessages.CreationSuccessResponse
            };
        }

    }
}
