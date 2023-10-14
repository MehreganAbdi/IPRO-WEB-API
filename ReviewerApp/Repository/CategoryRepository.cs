using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CategoryExists(int Id)
        {
            return _context.Categories.Any(c => c.Id == Id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(int Id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == Id);
        }

        public ICollection<Pokeman> GetPokemansByCategory(int CategoryId)
        {
            return _context.PokemanCategories.Where(c=>c.CategoryId == CategoryId).Select(p=>p.Pokeman).ToList();
        }
    }
}
