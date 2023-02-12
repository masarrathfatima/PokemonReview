using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IReviewerRepository
    {
        IEnumerable<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerid);
        ICollection<Review> GetReviewsByReviewer(int reviewerid);
        bool ReviewerExists(int reviewerid);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool Save();
        

    }
}
