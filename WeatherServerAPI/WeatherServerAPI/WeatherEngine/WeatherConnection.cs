using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.WeatherEngine
{
    public class WeatherConnection : IWeatherConnection
    {
        private const string apiKeyToken = "YuPiNsKCGY4kndMl8VWoTTC4S1UWxBV6";
        public async Task<AutocompleteResponse[]> GetLocationAutoComplete(string q)
        {
            AutocompleteResponse[] autocompleteResponse = null;
            try
            {
                var url = "http://dataservice.accuweather.com/locations/v1/cities/autocomplete" + "?apikey=" + apiKeyToken + "&q=" + q;
                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(url);              
                autocompleteResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<AutocompleteResponse[]>(json);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return autocompleteResponse;
        }

        public async Task<CurrentConditionsResponse> GetCurrentConditions(string locationKey)
        {
            CurrentConditionsResponse currentConditionsResponse = null;
            try
            {
                var url = "http://dataservice.accuweather.com/currentconditions/v1/" + locationKey + "/?apikey=" + apiKeyToken;
                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(url);             
                currentConditionsResponse = (Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentConditionsResponse[]>(json)).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return currentConditionsResponse;
        }
    }
}
