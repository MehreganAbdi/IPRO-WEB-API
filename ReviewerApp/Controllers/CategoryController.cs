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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var Categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(Categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();
            var Category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategoryById(categoryId));
            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(Category);
        }

        [HttpGet("pokeman/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokeman>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemanByCategoryId(int categoryId)
        {
            var pokemans = _mapper.Map<List<PokemanDTO>>(
                _categoryRepository.GetPokemansByCategory(categoryId)
                );

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(pokemans);
        }
        
    }
}
