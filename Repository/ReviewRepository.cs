using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class ReviewRepository:IReviewRepository
    {
        private readonly DataContext _context;

        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public Review GetReview(int id)
        {
            return _context.Reviews.Where(c => c.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewOfAPokemon(int pokeId)
        {
            return _context.Reviews.Where(r=>r.Pokemon.Id==pokeId).ToList();
        }

        public IEnumerable<Review> GetReviews()
        {
            return _context.Reviews.ToList();
        }

        public bool ReviewExist(int id)
        {
            return _context.Reviews.Any(c => c.Id == id);
        }
        public bool CreateReview(Review review)
        {
            _context.Add(review);
            return Save(); 


        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateReview(Review review)
        {
            _context.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _context.Remove(review);
            return Save();
        }

        public bool DeleteReviews(List<Review> reviews)
        {
            _context.RemoveRange(reviews);
            return Save();
        }
    }
}
