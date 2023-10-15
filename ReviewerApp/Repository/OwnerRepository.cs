using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
        public Owner GetOwner(int Id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == Id);
        }

        public ICollection<Owner> GetOwnerOfAPokeman(int pokemanId)
        {
            return _context.PokemanOwners.Where(p => p.PokemanId == pokemanId).Select(o => o.Owner).ToList();
        }

        public ICollection<Owner> GetOwners()
        {
            return _context.Owners.ToList();
        }

        public ICollection<Pokeman> GetPokemanByOwner(int ownerId)
        {
            return _context.PokemanOwners.Where(p => p.Owner.Id == ownerId).Select(u => u.Pokeman).ToList();
        }

        public bool OwnerExists(int ownerId)
        {
            return _context.Owners.Any(o => o.Id == ownerId);
        }
    }
}
