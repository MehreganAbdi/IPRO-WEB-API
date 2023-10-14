using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategoryById(int Id);
        ICollection<Pokeman> GetPokemansByCategory(int CategoryId);
        bool CategoryExists(int Id);
        
    }
}
