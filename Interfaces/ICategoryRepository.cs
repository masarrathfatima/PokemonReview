using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int categoryId);
        bool CreateCategory (Category category);
        bool UpdateCategory (Category category);
        bool DeleteCategory (Category category);
        bool Save();

    }
}
