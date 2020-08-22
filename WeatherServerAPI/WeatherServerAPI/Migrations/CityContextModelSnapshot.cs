﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherServerAPI.DataAccess;

namespace WeatherServerAPI.Migrations
{
    [DbContext(typeof(CityContext))]
    partial class CityContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WeatherServerAPI.Model.AutocompleteLight", b =>
                {
                    b.Property<string>("CityKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocalizedName");

                    b.HasKey("CityKey");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("WeatherServerAPI.Model.CurrentConditionsLight", b =>
                {
                    b.Property<string>("LocationKey")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocalizedName");

                    b.Property<string>("TemperatureInCelsius");

                    b.Property<string>("WeatherText");

                    b.HasKey("LocationKey");

                    b.ToTable("CurrentConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
