using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> GetReviews();
        Review GetReview(int id);
        ICollection<Review> GetReviewOfAPokemon(int pokeId);
        bool ReviewExist(int id);
        bool CreateReview(Review review);
        bool UpdateReview(Review review);
        bool Save();

    }
}
