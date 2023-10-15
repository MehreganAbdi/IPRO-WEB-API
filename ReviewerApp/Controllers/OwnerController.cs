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
    public class OwnerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOwnerRepository _ownerRepository;

        public OwnerController(IMapper mapper, IOwnerRepository ownerRepository)
        {
            _mapper = mapper;
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
        public IActionResult GetOwners()
        {
            var Ownerz = _mapper.Map<List<OwnerDTO>>(_ownerRepository.GetOwners());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Ownerz);
        }


        [HttpGet("{ownerId}")]
        [ProducesResponseType(200, Type = typeof(Country))]
        [ProducesResponseType(400)]
        public IActionResult GetOwner(int ownerId)
        {
            if (!_ownerRepository.OwnerExists(ownerId))
                return NotFound();
            var owner = _mapper.Map<OwnerDTO>(_ownerRepository.GetOwner(ownerId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(owner);
        }

        [HttpGet("pokeman/{OwnerId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokeman>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemanByOwner(int OwnerId)
        {
            var pokes = _mapper.Map<List<PokemanDTO>>(
                _ownerRepository.GetPokemanByOwner(OwnerId)
                );

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokes);
        }

        [HttpGet("Pokeman/{PokemanId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokeman>))]
        [ProducesResponseType(400)]
        public IActionResult GetOwnerOfAPokeman(int PokemanId)
        {
            var poke = _mapper.Map<PokemanDTO>(
                _ownerRepository.GetOwnerOfAPokeman(PokemanId)
                );


            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(poke);
        }

    }

}
