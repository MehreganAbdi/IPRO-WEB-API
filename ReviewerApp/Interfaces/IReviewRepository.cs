using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface IReviewRepository
    {
        ICollection<Review> GetAllReview();
        Review GetReviewById(int Id);
        bool ReviewExists(int Id);
        ICollection<Review> GetReviewsOfPokeman(int pokeId);

    }
}
