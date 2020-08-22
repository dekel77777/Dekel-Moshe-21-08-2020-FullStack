using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherServerAPI.Model;
using WeatherServerAPI.Repositories;

namespace WeatherServerAPI.WeatherEngine
{
    public class WeatherEngine : IWeatherEngine
    {
        private readonly IWeatherConnection _weatherConnection;
        private readonly IMapper _mapper;
        private readonly ICityRepository _cityRepository;

        public WeatherEngine(IWeatherConnection weatherConnection, IMapper mapper, ICityRepository cityRepository)
        {
            this._cityRepository = cityRepository;
            this._weatherConnection = weatherConnection;
            _mapper = mapper;
        }


        public async Task<AutocompleteLight[]> GetLocationAutoComplete(string q)
        {
            var autocompleteResponse = await _weatherConnection.GetLocationAutoComplete(q);
            AutocompleteLight[] autocompleteLight = null;
            if (autocompleteResponse != null)
            {
                autocompleteLight = _mapper.Map<AutocompleteLight[]>(autocompleteResponse);
                autocompleteLight = autocompleteLight.OrderBy(a => a.LocalizedName).ToArray();
            }
            return autocompleteLight;
        }

        public async Task<CurrentConditionsLight> GetCurrentConditions(string locationKey, string localizedName)
        {
            //find in DB first
            var currentConditionsLight = await _cityRepository.GetCurrentConditions(locationKey);
            if (currentConditionsLight != null)
            {
                return currentConditionsLight;
            }
            
            //not existed in DB, send API request
            var currentConditionsResponse = await _weatherConnection.GetCurrentConditions(locationKey);
            
            if (currentConditionsResponse != null)
            {
                currentConditionsLight = _mapper.Map<CurrentConditionsLight>(currentConditionsResponse);
                currentConditionsLight.LocationKey = locationKey;
                currentConditionsLight.LocalizedName = localizedName;
                await _cityRepository.AddCurrentConditions(currentConditionsLight); //insert current condition into DB
            }


            return currentConditionsLight;
        }

        public async Task SaveFavoriteCity(AutocompleteLight favorite)
        {
            await _cityRepository.AddCityToFavorites(favorite);
        }

        public async Task<AutocompleteLight[]> DeleteCityFromFavorites(string locationKey)
        {
            await _cityRepository.DeleteCityFromFavorites(locationKey);
            var favorites = await GetAllFavorites();
            return favorites;
        }

        public async Task<AutocompleteLight[]> GetAllFavorites()
        {
            var favorites = await _cityRepository.GetAllFavorites();
            if (favorites != null && favorites.Length > 0)
            {
                favorites = favorites.OrderBy(a => a.LocalizedName).ToArray();
            }
            return favorites;
        }
    }
}
