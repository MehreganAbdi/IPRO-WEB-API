using ReviewerApp.Models;

namespace ReviewerApp.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GetAllReviewers();
        Reviewer GetReviewerById(int Id);
        ICollection<Review> GetReviewsByReviwer(int ReviewerId);
        bool ReviwerExists(int Id);
    }
}
