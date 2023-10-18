using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Review> GetAllReview()
        {
            return _context.Reviews.ToList();
        }

        public Review GetReviewById(int Id)
        {
            return _context.Reviews.FirstOrDefault(r => r.Id == Id);
        }

        public ICollection<Review> GetReviewsOfPokeman(int pokeId)
        {
            return _context.Reviews.Where(r => r.Pokeman.Id == pokeId).ToList();
        }

        public bool ReviewExists(int Id)
        {
            return _context.Reviews.Any(r => r.Id == Id);
        }
    }
}
