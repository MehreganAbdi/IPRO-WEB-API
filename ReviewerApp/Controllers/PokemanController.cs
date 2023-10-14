using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ReviewerApp.DTOs;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemanController : Controller
    {
        private readonly IPokemanRepository _pokemanRepository;
        private readonly IMapper _mapper;

        public PokemanController(IPokemanRepository pokemanRepository , IMapper mapper)
        {
            _pokemanRepository = pokemanRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokeman>))]
        public IActionResult GetPokemans()
        {
            var pokemans = _mapper.Map<List<PokemanDTO>>(_pokemanRepository.GetAllPokemans());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemans);
        }

        [HttpGet("{pokeId}")]
        [ProducesResponseType(200,Type = typeof(Pokeman))]
        [ProducesResponseType(400)]
        public IActionResult GetPokeman(int pokeId)
        {
            if(!_pokemanRepository.PokemanExists(pokeId))
                    return NotFound();
            var pokeman = _mapper.Map<PokemanDTO>(_pokemanRepository.GetById(pokeId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokeman);
        }


        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemanRating(int pokeId)
        {
            if (!_pokemanRepository.PokemanExists(pokeId))
                return NotFound();
            var rating= _pokemanRepository.GetPokemanRating(pokeId);
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(rating);
        }
    }
}
