#nullable disable
using AutoMapper;
using HotelListing.API.Data.Model;
using HotelListing.API.Models.Country;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly HotelListingDbContext _context;
        private readonly IMapper _mapper;

        public CountriesController(HotelListingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryListDto>>> GetCountries()
        {
            var countries = await _context.Countries.ToListAsync();
            var records = _mapper.Map<List<GetCountryListDto>>(countries);

            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetailsDto>> GetCountry(int id)
        {
            var country = await _context.Countries.Include(x => x.Hotels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (country == null)
            {
                return NotFound();
            }

            var getCountryDetailsDto = _mapper.Map<GetCountryDetailsDto>(country);

            return Ok(getCountryDetailsDto);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updateCountryDto)
        {
            if (id != updateCountryDto.Id)
            {
                return BadRequest("Invalid Record Id");
            }

            //_context.Entry(country).State = EntityState.Modified;

            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCountryDto, country);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // overposting: preventing the user from submitting data that we don't want, or that could potentialy be harmful for the system
        [HttpPost]
        public async Task<ActionResult<GetCountryDetailsDto>> PostCountry(CreateCountryDto createCountryDto)
        {
            var country = _mapper.Map<Country>(createCountryDto);

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();

            var getCountryDetailsDto = _mapper.Map<GetCountryDetailsDto>(country);

            return CreatedAtAction("GetCountry", new { id = getCountryDetailsDto.Id }, getCountryDetailsDto);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
