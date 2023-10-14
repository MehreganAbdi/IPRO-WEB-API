using AutoMapper;
using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public bool CountryExists(int Id)
        {
            return _context.Countries.Any(c => c.Id == Id);
        }

        public ICollection<Country> GetAllCountries()
        {
            return _context.Countries.ToList();
        }

        public Country GetCountryById(int Id)
        {
            return _context.Countries.FirstOrDefault(c => c.Id == Id);
        }

        public Country GetCountryByOwnerId(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(r => r.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersFromACountry(int countryId)
        {
            return _context.Owners.Where(c =>c.Country.Id == countryId).ToList();
        }
    }
}
