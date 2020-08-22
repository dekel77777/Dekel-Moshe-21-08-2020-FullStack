using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherServerAPI.Model
{
    public class AutocompleteLight
    {
        [Key]
        public string CityKey { get; set; }
        public string LocalizedName { get; set; }
    }
}
