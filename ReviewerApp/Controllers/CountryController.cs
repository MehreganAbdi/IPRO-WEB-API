using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ReviewerApp.DTOs;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;
using ReviewerApp.Repository;

namespace ReviewerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryController(ICountryRepository countryRepository , IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDTO>))]
        public IActionResult GetCountries()
        {
            var Countries = _mapper.Map<List<CountryDTO>>(_countryRepository.GetAllCountries());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Countries);
        }

        [HttpGet("{countryId}")]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        [ProducesResponseType(400)]
        public IActionResult GetCountry(int countryId)
        {
            if (!_countryRepository.CountryExists(countryId))
                return NotFound();
            var Country = _mapper.Map<CountryDTO>(_countryRepository.GetCountryById(countryId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(Country);
        }

        [HttpGet("/owners/{ownerId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(CountryDTO))]
        public IActionResult GetCountryOfAnOwner(int ownerId)
        {
            var country = _mapper.Map<CountryDTO>(
                _countryRepository.GetCountryByOwnerId(ownerId));

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(country);
        }
    }
}
