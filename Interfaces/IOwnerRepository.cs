using PokemonReview.Models;

namespace PokemonReview.Interfaces
{
    public interface IOwnerRepository
    {
        bool OwnersExist(int ownerId);
        IEnumerable<Owner> GetOwners();
        Owner GetOwnerById(int ownerId);
        IEnumerable<Pokemon> GetPokemonsByOwner(int ownerId);
        IEnumerable<Owner> GetOwnersOfAPokemon(int pokemonId);
        bool CreateOwner(Owner owner);
        bool UpdateOwner(Owner owner);

        bool Save();


        

    }
}
