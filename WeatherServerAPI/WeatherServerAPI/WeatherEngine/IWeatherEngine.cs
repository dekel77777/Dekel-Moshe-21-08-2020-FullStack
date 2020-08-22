using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.WeatherEngine
{
    public interface IWeatherEngine
    {
        Task<AutocompleteLight[]> GetLocationAutoComplete(string q);
        Task<CurrentConditionsLight> GetCurrentConditions(string locationKey, string localizedName);
        Task SaveFavoriteCity(AutocompleteLight favorite);
        Task<AutocompleteLight[]> DeleteCityFromFavorites(string locationKey);
        Task<AutocompleteLight[]> GetAllFavorites();
    }
}
