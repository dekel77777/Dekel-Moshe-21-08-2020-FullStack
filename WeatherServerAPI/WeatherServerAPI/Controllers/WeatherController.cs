using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherServerAPI.Model;
using WeatherServerAPI.WeatherEngine;

namespace WeatherServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : Controller
    {
        private readonly IWeatherEngine _weatherEngine;

        public WeatherController(IWeatherEngine weatherEngine)
        {
            this._weatherEngine = weatherEngine;
        }

        [HttpGet]
        public async Task GetAsync(string q)
        {
        }

        [HttpGet]
        [Route("GetLocationAutoComplete")]
        public async Task<AutocompleteLight[]> GetLocationAutoComplete(string q)
        {
            var autocompleteLights = await _weatherEngine.GetLocationAutoComplete(q);
            return autocompleteLights;
        }

        [HttpGet]
        [Route("GetCurrentConditions")]
        public async Task<CurrentConditionsLight> GetCurrentConditions(string locationKey, string localizedName)
        {
            //locationKey = "2332712";
            var currentConditionsLight = await _weatherEngine.GetCurrentConditions(locationKey, localizedName);
            return currentConditionsLight;
        }

        [HttpPost]
        [Route("SaveFavoriteCity")]
        public async Task SaveFavoriteCity(AutocompleteLight favorite)
        {
            await _weatherEngine.SaveFavoriteCity(favorite);
        }

        [HttpGet]
        [Route("GetAllFavorites")]
        public async Task<AutocompleteLight[]> GetAllFavorites()
        {
            var favorites = await _weatherEngine.GetAllFavorites();
            return favorites;
        }

        [HttpDelete]
        [Route("DeleteCityFromFavorites")]
        public async Task<AutocompleteLight[]> DeleteCityFromFavorites(string locationKey)
        {
            var favorites = await _weatherEngine.DeleteCityFromFavorites(locationKey);
            return favorites;

        }
    }
}
