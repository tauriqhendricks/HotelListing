using AutoMapper;
using HotelListing.API.Data.Model;
using HotelListing.API.Models.Country;

namespace HotelListing.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
        }
    }
}
