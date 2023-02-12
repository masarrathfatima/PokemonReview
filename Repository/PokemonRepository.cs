using Microsoft.AspNetCore.Mvc;
using PokemonReview.Data;
using PokemonReview.Dto;
using PokemonReview.Interfaces;
using PokemonReview.Models;

namespace PokemonReview.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;
        public PokemonRepository(DataContext context) 
        {
            _context= context;
        }
        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemon(int pokeid)
        {
            return _context.Pokemons.Where(p => p.Id == pokeid).FirstOrDefault();

        }

        public Pokemon GetPokemon(string name)
        {
            return _context.Pokemons.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeid)
        {
            var reviews = _context.Reviews.Where(p => p.Id == pokeid);
            if(reviews.Count() <=0 ) 
            {
                return 0;
            }
            return((decimal)reviews.Sum(review => review.Rating)/reviews.Count());
        }

        public bool PokemonExists(int pokeid)
        {
            return _context.Pokemons.Any(p=>p.Id== pokeid);
           
        }

        public bool CreatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            var pokemonOwnerEntity = _context.Owners.Where(o=>o.Id== ownerId).FirstOrDefault();
            var categoryEntity = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
            var pokemonOwner = new PokemonOwner()
            {
                Owner = pokemonOwnerEntity,
                Pokemon = pokemon,
            };
            _context.Add(pokemonOwner);
            var pokemonCategory = new PokemonCategory()
            {
                Category = categoryEntity,
                Pokemon = pokemon,

            };
            _context.Add(pokemonCategory);
            _context.Add(pokemon);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdatePokemon(int ownerId, int categoryId, Pokemon pokemon)
        {
            _context.Update(pokemon);
            return Save();
        }

        public bool DeletePokemon(Pokemon pokemon)
        {
            _context.Remove(pokemon);
            return Save();
        }
    }
}
