using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetAllCountries();
        Country GetCountryById(int Id);
        Country GetCountryByOwnerId(int ownerId);
        bool CountryExists(int Id);
        ICollection<Owner> GetOwnersFromACountry(int countryId);
    }
}
