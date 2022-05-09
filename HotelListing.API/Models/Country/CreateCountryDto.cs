using System.ComponentModel.DataAnnotations;

namespace HotelListing.API.Models.Country
{
    public class CreateCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
