using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int Id);
        ICollection<Owner> GetOwnerOfAPokeman(int pokemanId);
        ICollection<Pokeman> GetPokemanByOwner(int ownerId);
        bool OwnerExists(int ownerId);
    }
}
