using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Enums;
using ECommerce.Application.Contracts;
using ECommerce.Application.DTO_S.Requests;
using ECommerce.Application.Helpers;
using ECommerce.Data.Contract;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ECommerce.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repository;

        public CustomerService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<SuccessResponse<string>> CreateCustomer(CreateCustomer request)
        {
            var customerExists = await _repository.CustomerRepository.ExistsAsync(x => x.PhoneNumber == request.PhoneNumber);

            if (customerExists)
            {
                throw new RestException(HttpStatusCode.BadRequest, ResponseMessages.DuplicatePhoneNumber);
            }

            var customer = new Customer
            {
                PhoneNumber = request.PhoneNumber,
                DateJoined = request.DateJoined,
                FullName = request.FullName,
                TotalAmountSpent = request.TotalAmountSpent,
            };
            await _repository.CustomerRepository.CreateAsync(customer);
            var result = await _repository.SaveChangesAsync();

            return new SuccessResponse<string>
            {
                Message = "Created Successfully"
            };

        }

        public async Task<SuccessResponse<List<Discount>>> ProfileCustomer(string phoneNumber)
        {
            var customer = await _repository.CustomerRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber, false);

            if (customer == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, ResponseMessages.UserNotFound);
            }

            var totalDays = (int)(DateTime.Now - customer.DateJoined).TotalDays;

            var discounts = await _repository.DiscountRepository.FindByCondition(x => (x.DiscountType == DiscountType.MonthBased && x.Requirement * 30 <= totalDays) || (x.DiscountType == DiscountType.AmountSpent && x.Requirement <= customer.TotalAmountSpent), false).ToListAsync();

            return new SuccessResponse<List<Discount>>
            {
                Data = discounts
            };

        }

        public async Task<SuccessResponse<string>> UpdateCustomer(string phoneNumber, UpdateCustomer request)
        {
            var customer = await _repository.CustomerRepository.FirstOrDefaultAsync(x => x.PhoneNumber == phoneNumber, true);

            if (customer == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, ResponseMessages.UserNotFound);
            }

            customer.TotalAmountSpent = request.TotalAmountSpent;
            customer.DateJoined = request.DateJoined;

            await _repository.SaveChangesAsync();

            return new SuccessResponse<string>
            {
                Message = ResponseMessages.UpdateSuccessResponse
            };
        }
    }
}
