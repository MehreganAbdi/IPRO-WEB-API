using Microsoft.AspNetCore.Mvc.Rendering;
using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class PokemanRepository : IPokemanRepository
    {
        private readonly DataContext _context;
        public PokemanRepository(DataContext context)
        {
            _context = context; 
        }

        public ICollection<Pokeman> GetAllPokemans()
        {
            return _context.Pokemans.ToList();
        }

        public Pokeman GetById(int Id)
        {
            return _context.Pokemans.FirstOrDefault(p => p.Id == Id); 
        }

        public Pokeman GetByName(string Name)
        {
            return _context.Pokemans.FirstOrDefault(p => p.Name == Name);
        }

        public int GetPokemanRating(int id)
        {
            var review = _context.Reviews.Where(r => r.Pokeman.Id == id);
            if (review.Count()<= 0)
                return 0;
            return ((int)review.Sum(r => r.Rating) / review.Count());
        }

        public bool PokemanExists(int Id)
        {
            return _context.Pokemans.FirstOrDefault(p => p.Id == Id) != null ? true : false;
        }
    }
}
