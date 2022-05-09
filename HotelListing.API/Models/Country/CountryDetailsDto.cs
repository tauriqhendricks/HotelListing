using HotelListing.API.Models.Hotel;

namespace HotelListing.API.Models.Country
{
    public class CountryDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        

        public  List<HotelDetailsDto> Hotels { get; set; }
    }
}
