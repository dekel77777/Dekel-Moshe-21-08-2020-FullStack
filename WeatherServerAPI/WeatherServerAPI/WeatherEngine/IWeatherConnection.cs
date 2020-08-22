using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.WeatherEngine
{
    public interface IWeatherConnection
    {
        Task<AutocompleteResponse[]> GetLocationAutoComplete(string q);
        Task<CurrentConditionsResponse> GetCurrentConditions(string locationKey);
    }
}
