using AutoMapper;
using Common.Dto;
using DataAccess.Entities;

namespace BusinessLayer.AutoMapperProfile;

public class BusinessLogicProfile : Profile
{
    public BusinessLogicProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
