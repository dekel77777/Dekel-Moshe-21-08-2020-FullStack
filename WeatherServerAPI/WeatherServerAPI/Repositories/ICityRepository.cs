using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.Repositories
{
    public interface ICityRepository
    {
        Task AddCurrentConditions(CurrentConditionsLight currentConditions);
        Task<CurrentConditionsLight> GetCurrentConditions(string LocationKey);
        Task AddCityToFavorites(AutocompleteLight favorite);
        Task<AutocompleteLight[]> GetAllFavorites();
        Task<bool> DeleteCityFromFavorites(string locationKey);
    }
}
