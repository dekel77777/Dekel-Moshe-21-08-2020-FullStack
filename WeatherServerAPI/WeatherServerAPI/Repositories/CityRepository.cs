using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherServerAPI.DataAccess;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.Repositories
{
    public class CityRepository : ICityRepository
    {
        protected readonly CityContext _dbContext;

        public CityRepository(CityContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AddCurrentConditions(CurrentConditionsLight currentConditions)
        {
            await _dbContext.CurrentConditions.AddAsync(currentConditions);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CurrentConditionsLight> GetCurrentConditions(string LocationKey)
        {
            var currentConditions = await _dbContext.CurrentConditions.FindAsync(LocationKey);
            return currentConditions;
        }

        public async Task AddCityToFavorites(AutocompleteLight favorite)
        {
            await _dbContext.Favorites.AddAsync(favorite);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteCityFromFavorites(string locationKey)
        {
            var autocompleteLight = await _dbContext.Favorites.FindAsync(locationKey);
            if (autocompleteLight != null)
            {
                _dbContext.Favorites.Remove(autocompleteLight);
                await _dbContext.SaveChangesAsync();
            }
           
           return true;
        }

        public async Task<AutocompleteLight[]> GetAllFavorites()
        {
            var favorites = await _dbContext.Favorites.ToArrayAsync();
            return favorites;
        }

    }
}
