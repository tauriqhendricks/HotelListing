using AutoMapper;
using HotelListing.API.Data.Model;
using HotelListing.API.Models.Country;
using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            // COUNTRY
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDetailsDto>().ReverseMap();
            CreateMap<Country, GetCountryListDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();

            // HOTEL
            CreateMap<Hotel, HotelDetailsDto>().ReverseMap();
        }
    }
}
