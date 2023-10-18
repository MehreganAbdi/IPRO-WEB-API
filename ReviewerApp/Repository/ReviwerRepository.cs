using ReviewerApp.Data;
using ReviewerApp.Interfaces;
using ReviewerApp.Models;

namespace ReviewerApp.Repository
{
    public class ReviwerRepository : IReviewerRepository
    {
        private readonly DataContext _context;
        public ReviwerRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Reviewer> GetAllReviewers()
        {
            return _context.Reviewers.ToList();

        }

        public Reviewer GetReviewerById(int Id)
        {
            return _context.Reviewers.FirstOrDefault(r => r.Id == Id);
        }

        public ICollection<Review> GetReviewsByReviwer(int ReviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == ReviewerId).ToList();
        }

        public bool ReviwerExists(int Id)
        {
            return _context.Reviews.Any(r => r.Id == Id);
        }
    }
}
