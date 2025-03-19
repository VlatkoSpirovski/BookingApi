using AutoMapper;
using BookingApi.Domain.Entities;
using BookingApi.Domain.ResponseModels;

namespace BookingApi.BusinessLogic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Property, PropertyResponseModel>();
            CreateMap<PropertyAmenity, PropertyAmenityResponseModel>();
            CreateMap<User, UserResponseModel>();
        }
    }
}