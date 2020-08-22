using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServerAPI.Model
{
    public class CurrentConditionsLight
    {
        [Key]
        public string LocationKey { get; set; }
        public string WeatherText { get; set; }
        public string TemperatureInCelsius { get; set; }
        public string LocalizedName { get; set; }
    }
}
