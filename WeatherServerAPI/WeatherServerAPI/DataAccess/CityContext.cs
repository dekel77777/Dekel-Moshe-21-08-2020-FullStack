using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherServerAPI.Model;

namespace WeatherServerAPI.DataAccess
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions options) : base(options) { }
        public DbSet<AutocompleteLight> Favorites { get; set; }
        public DbSet<CurrentConditionsLight> CurrentConditions { get; set; }

    }
}
