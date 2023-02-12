using PokemonReview.Data;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _dataContext;

        public OwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateOwner(Owner owner)
        {
            _dataContext.Add(owner);
            return Save();
        }

        public bool DeleteOwner(Owner owner)
        {
            _dataContext.Remove(owner);
            return Save();
        }

        public Owner GetOwnerById(int ownerId)
        {
            return _dataContext.Owners.Where(o => o.Id == ownerId).FirstOrDefault();
        }

        public IEnumerable<Owner> GetOwners()
        {
            return _dataContext.Owners.OrderBy(o=>o.Id).ToList();

        }

        public IEnumerable<Owner> GetOwnersOfAPokemon(int pokemonId)
        {
            return _dataContext.PokemonOwners.Where(p=>p.PokemonId== pokemonId).Select(o=>o.Owner).ToList();
        }

        public IEnumerable<Pokemon> GetPokemonsByOwner(int ownerId)
        {
            return _dataContext.PokemonOwners.Where(p=>p.OwnerId==ownerId).Select(o=>o.Pokemon).ToList();
        }

        public bool OwnersExist(int ownerId)
        {
            return _dataContext.Owners.Any(c=>c.Id==ownerId);
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateOwner(Owner owner)
        {
            _dataContext.Update(owner);
            return Save();
        }
    }
}
