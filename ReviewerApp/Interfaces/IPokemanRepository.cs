using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface IPokemanRepository
    {
        ICollection<Pokeman> GetAllPokemans();
        Pokeman GetById(int Id);
        Pokeman GetByName(string Name);
        int GetPokemanRating(int id);
        bool PokemanExists(int Id);
    }
}
