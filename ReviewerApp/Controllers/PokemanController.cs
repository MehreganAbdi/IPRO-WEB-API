using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemanController : Controller
    {
        private readonly IPokemanRepository _pokemanRepository;

        public PokemanController(IPokemanRepository pokemanRepository)
        {
            this._pokemanRepository = pokemanRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokeman>))]
        public IActionResult GetPokemans()
        {
            var pokemans = _pokemanRepository.GetAllPokemans();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemans);
        }
    
    }
}
