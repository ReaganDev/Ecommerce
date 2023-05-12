using AutoMapper;
using Ecommerce.Domain.Entities;
using ECommerce.Application.DTO_S.Requests;

namespace ECommerce.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomer, Customer>();
        }
    }
}
